using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : Singleton
{
    public LevelScript CurrentLevelScript;
    public BuildController BuildController;
    public BansheeGz.BGSpline.Components.BGCcMath CurrentLevelSpline;
    public static GameController Instance;
    bool BuildingMode;
    public int Money;
    public MusicManager MusicManager;
    public List<TurretBase> Turrets;
    void Start()
    {
        Init();
        Instance = this;
        GameEvents.OnLevelLoaded_c(gameObject.scene);
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
                Debug.Break();
#endif
                GameEvents.OnGameWin_c();
            }
        }
    }

}
