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
