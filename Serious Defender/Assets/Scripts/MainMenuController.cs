using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnLevelLoaded += GameEvents_OnLevelLoaded;
        GameEvents.OnFadeScreenScreenCoverd += GameEvents_OnFadeScreenScreenCoverd;
    }

    private void GameEvents_OnFadeScreenScreenCoverd()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }

    private void GameEvents_OnLevelLoaded(Scene scene)
    {
        if (String.Equals(scene.name, "DontDestroyOnLoad"))
        {
        GameEvents.OnMusicStateChanged_c(MusicState.MENU);
        }
    }

    private void OnDisable()
    {
        GameEvents.OnLevelLoaded -= GameEvents_OnLevelLoaded;
        GameEvents.OnFadeScreenScreenCoverd -= GameEvents_OnFadeScreenScreenCoverd;
    }
    void Start()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

       
    }

    public void LoadLevelGame()
    {
      
          GameEvents.FadeScreenIN_c();
        Debug.Log("Star");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
