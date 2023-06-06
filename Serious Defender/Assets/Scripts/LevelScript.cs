using BansheeGz.BGSpline.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class LevelScript : MonoBehaviour
{
    [SerializeField] BGCcMath SplineMath;
    public List<EnemyBase> EnemiesOnLevel = new List<EnemyBase>();
    public List<TurretBase> TurretPlacedInLevel = new List<TurretBase>();
    public LevelObject levelObject;
    public int CurrentWave;
    public bool AllUnitsSpawned;
    [SerializeField] AudioClip LevelMusic;
    public Transform EnemySpawner;
    public bool IsSpawning;
    private void OnEnable()
    {
        GameEvents.OnLevelLoaded += GameEvents_OnLevelLoaded;
        GameEvents.OnNextWave += GameEvents_OnNextWave;
      
    }

 

    private void GameEvents_OnNextWave()
    {
        StartCoroutine(NextWave());
    }

    private void OnDisable()
    {
        GameEvents.OnLevelLoaded -= GameEvents_OnLevelLoaded; GameEvents.OnNextWave -= GameEvents_OnNextWave;
        foreach (TurretBase tb in TurretPlacedInLevel)
        {
            Destroy(tb.gameObject);
        }
        TurretPlacedInLevel.Clear();
        GameController.Instance.Money = 5000;
    }
    private void GameEvents_OnLevelLoaded(UnityEngine.SceneManagement.Scene scene)
    {
        GameEvents.OnMusicStateChanged_c(MusicState.GAME, LevelMusic);
        if (scene.name.Contains("Level"))
        {
          
        }
    }

    void Start()
    {
        GameEvents.OnLevelLoaded_c(gameObject.scene);

        if (SplineMath != null)
        {
            GameController.Instance.CurrentLevelSpline = SplineMath;
        }
        GameController.Instance.CurrentLevelScript = this;
        GameController.Instance.CameraController.SetCameraOnEnemy();
    }

    public IEnumerator NextWave()
    {
        if (CurrentWave > levelObject.WaveScenario.Count)
        {
#if UNITY_EDITOR
            Debug.Break();
#endif
            GameEvents.OnGameWin_c();
            yield return null;
        }
        IsSpawning = true;
        AllUnitsSpawned = false;
        Wave wave = levelObject.WaveScenario[CurrentWave];
        CurrentWave++;
        foreach (EnemyPack ep in wave.EnemyTypesInWave)
        {
            for (int amount = 0; amount < ep.Amount; amount++)
            {
                Instantiate(ep.Type);
                yield return new WaitForSeconds(ep.SpawnTime);
            }
            AllUnitsSpawned = true;
        }
        IsSpawning = false;
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(LevelScript), true)]
public class LevelScripted : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        LevelScript ls = (LevelScript)target;
        if (GUILayout.Button("NextWave"))
        {
            ls.StartCoroutine(ls.NextWave());
        }
    }
}
#endif