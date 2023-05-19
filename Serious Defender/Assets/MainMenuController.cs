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
    }
    void Start()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
       
    }

    public void LoadLevelGame()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
