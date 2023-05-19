using BansheeGz.BGSpline.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class LevelScript : MonoBehaviour
{
    [SerializeField] BGCcMath SplineMath;
    public List<EnemyBase> EnemiesOnLevel = new List<EnemyBase>();
    [SerializeField] LevelObject levelObject;
    public int CurrentWave;
    public bool AllUnitsSpawned;
    [SerializeField] AudioClip LevelMusic;
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
    }
    private void GameEvents_OnLevelLoaded(UnityEngine.SceneManagement.Scene scene)
    {
        GameEvents.OnMusicStateChanged_c(MusicState.GAME, LevelMusic);
    }

    void Start()
    {
        GameEvents.OnLevelLoaded_c(gameObject.scene);
       
        if (SplineMath != null)
        {
            GameController.Instance.CurrentLevelSpline = SplineMath;
        }
        GameController.Instance.CurrentLevelScript = this;
    }

    public IEnumerator NextWave()
    {

        Wave wave = levelObject.WaveScenario[CurrentWave];
        foreach (EnemyPack ep in wave.EnemyTypesInWave)
        {
            for (int amount = 0; amount < ep.Amount; amount++)
            {
                Instantiate(ep.Type);
                yield return new WaitForSeconds(ep.SpawnTime);
            }
            AllUnitsSpawned = true;
        }
        CurrentWave++;
    }
}
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