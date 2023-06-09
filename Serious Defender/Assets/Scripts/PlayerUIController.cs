using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] GameObject PlayerUI;
    [SerializeField] TextMeshProUGUI Money;
    [SerializeField] TextMeshProUGUI Wave;
    [SerializeField] GameObject NextWaveBtn;
    [SerializeField] GameObject FailedGame;
    [SerializeField] GameObject WinGame;
    [SerializeField] Image HpFill;
    private void OnEnable()
    {
        GameEvents.OnLevelLoaded += GameEvents_OnLevelLoaded;
        GameEvents.OnGameFailed += GameEvents_OnGameFailed;
        GameEvents.OnGameWin += GameEvents_OnGameWin;
    }

    private void GameEvents_OnGameWin()
    {
        WinGame.SetActive(true);
        PlayerUI.SetActive(false);
    }
 
    public void PlayAgain()
    {
        GameEvents.OnLoadNextLevel_c();
    }
    public void OnMissleActivated()
    {
        GameEvents.OnMissle_c();
    }
    private void GameEvents_OnGameFailed()
    {
        FailedGame.SetActive(true);
        PlayerUI.SetActive(false);
    }

    private void Update()
    {
        if (GameController.Instance && HpFill)
        {
            HpFill.fillAmount =  Mathf.InverseLerp(0,100, GameController.Instance.PlayerHp) ;
        }
            if (Money != null)
        {
            Money.text = GameController.Instance.Money.ToString();
        }
        if (Wave != null && GameController.Instance.CurrentLevelScript != null && GameController.Instance != null)
        {
            Wave.text = GameController.Instance.CurrentLevelScript.CurrentWave.ToString();
        }
        if (GameController.Instance.CurrentLevelScript != null && !GameController.Instance.CurrentLevelScript.AllUnitsSpawned && GameController.Instance.CurrentLevelScript.EnemiesOnLevel.Count > 0 &&  GameController.Instance.CurrentLevelScript.EnemiesOnLevel!= null)
        {
            NextWaveBtn.SetActive(false);
        }
        else if (GameController.Instance.CurrentLevelScript != null && GameController.Instance.CurrentLevelScript.AllUnitsSpawned && GameController.Instance.CurrentLevelScript.EnemiesOnLevel.Count <= 0)
        {
            NextWaveBtn.SetActive(true);
        }
    }
    private void GameEvents_OnLevelLoaded(UnityEngine.SceneManagement.Scene scene)
    {
        if (scene.name.Contains("Level"))
        {
            PlayerUI.SetActive(true);
            WinGame.SetActive(false);
        }
    }
    public void NextWave()
    {
        GameEvents.OnNextWave_c();
    }
    private void OnDisable()
    {
        GameEvents.OnGameFailed -= GameEvents_OnGameFailed;
        GameEvents.OnLevelLoaded -= GameEvents_OnLevelLoaded;
        GameEvents.OnGameWin -= GameEvents_OnGameWin;
    }

}
