using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton
{
    public CameraController CameraController;
    public LevelScript CurrentLevelScript;
    public BuildController BuildController;
    public BansheeGz.BGSpline.Components.BGCcMath CurrentLevelSpline;
    public static GameController Instance;
    bool BuildingMode;
    public int Money;
    public MusicManager MusicManager;
    public List<TurretBase> Turrets;
    public Scene CurrentLevel;
    void Start()
    {
        Init();
        Instance = this;
        GameEvents.OnLevelLoaded_c(gameObject.scene);
        GameEvents.OnGameControllerInit_c();
        PrepareScens();
    }
    private void OnEnable()
    {
        GameEvents.OnLevelLoaded += GameEvents_OnLevelLoaded;
        GameEvents.OnLoadNextLevel += LoadNextLevel;
    }
    private void OnDisable()
    {
        GameEvents.OnLevelLoaded -= GameEvents_OnLevelLoaded;
        GameEvents.OnLoadNextLevel -= LoadNextLevel;
    }
    private void GameEvents_OnLevelLoaded(UnityEngine.SceneManagement.Scene scene)
    {
        if (scene.name.Contains("Level"))
        {
            CurrentLevel = scene;
        }
    }
    public List<Scene> ScenesInBuildIndex=new List<Scene>();
    private void PrepareScens()
    {
        int scenesInBuidIndex = SceneManager.sceneCountInBuildSettings - 1;
        
        for(int i =2; i < scenesInBuidIndex; i++)
        {
            ScenesInBuildIndex.Add(SceneManager.GetSceneByBuildIndex(i));
        }
        
    }
    public void LoadNextLevel()
    {
        if (CurrentLevel.buildIndex <= 4)
        {
            //fade-in
            SceneManager.LoadSceneAsync(CurrentLevel.buildIndex+1, LoadSceneMode.Additive);
            SceneManager.UnloadScene(CurrentLevel.buildIndex);
        //fade-off
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BuildingMode = !BuildingMode;
            GameEvents.OnbuildingModeChanged_c(BuildingMode);
        }

        if (GameController.Instance.CurrentLevelScript != null)
        {
            if (GameController.Instance.CurrentLevelScript.CurrentWave >= GameController.Instance.CurrentLevelScript.levelObject.WaveScenario.Count&& GameController.Instance.CurrentLevelScript.EnemiesOnLevel.Count==0&& GameController.Instance.CurrentLevelScript.AllUnitsSpawned)
            {
#if UNITY_EDITOR
               /// Debug.Break();
#endif
                GameEvents.OnGameWin_c();
            }
        }
    }

}
