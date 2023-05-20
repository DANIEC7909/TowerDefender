using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] GameObject PlayerUI;
    [SerializeField] TextMeshProUGUI Money;
    [SerializeField] TextMeshProUGUI Wave;
    [SerializeField] GameObject NextWaveBtn;
    private void OnEnable()
    {
        GameEvents.OnLevelLoaded += GameEvents_OnLevelLoaded;
    }
    private void Update()
    {
        if (Money != null)
        {
            Money.text = GameController.Instance.Money.ToString();
        }
        if (Wave != null)
        {
            Wave.text = GameController.Instance.CurrentLevelScript.CurrentWave.ToString();
        }
        if (!GameController.Instance.CurrentLevelScript.AllUnitsSpawned &&GameController.Instance.CurrentLevelScript.EnemiesOnLevel.Count>0)
        {
            NextWaveBtn.SetActive(false);
        }
        else if (GameController.Instance.CurrentLevelScript.AllUnitsSpawned && GameController.Instance.CurrentLevelScript.EnemiesOnLevel.Count <= 0)
        {
            NextWaveBtn.SetActive(true);
        }
    }
    private void GameEvents_OnLevelLoaded(UnityEngine.SceneManagement.Scene scene)
    {
        if (String.Equals(scene.name, "Level1"))
        {
            PlayerUI.SetActive(true);
        }
    }
    public void NextWave()
    {
        GameEvents.OnNextWave_c();
    }
    private void OnDisable()
    {
        GameEvents.OnLevelLoaded -= GameEvents_OnLevelLoaded;
    }

}
