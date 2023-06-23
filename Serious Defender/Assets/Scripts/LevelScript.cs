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
    public Missle missle;
    public LevelObject levelObject;
    public int CurrentWave;
    public bool AllUnitsSpawned;
    [SerializeField] AudioClip LevelMusic;
    public Transform EnemySpawner;
    float SplineDistance;
    Vector3 firstCameraPos;
    public int Money = 5000;
    public bool IsSpawning;
    private void OnEnable()
    {
        GameEvents.OnLevelLoaded += GameEvents_OnLevelLoaded;
        GameEvents.OnNextWave += GameEvents_OnNextWave;
        GameEvents.OnFadeScreenOUT += GameEvents_OnFadeScreenOUT;

        GameController.Instance.Money = Money;
    }
    
    private void GameEvents_OnFadeScreenOUT()
    {
        GameController.Instance.PathShowInProgress = true;
        SplineDistance = SplineMath.GetDistance();
        firstCameraPos = GameController.Instance.CameraController.transform.position;
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

    }
    private void GameEvents_OnLevelLoaded(UnityEngine.SceneManagement.Scene scene)
    {
        GameEvents.OnMusicStateChanged_c(MusicState.GAME);
        if (scene.name.Contains("Level"))
        {
          
        }
    }
    float pathShowingProgress;
    
    float homeCameraLerp;
    Vector3 LastPosition;
    
    private void FixedUpdate()
    {
    

        if (GameController.Instance.PathShowInProgress&& GameController.Instance.CameraController)
        {
            if (pathShowingProgress < SplineDistance)
            {
                pathShowingProgress += Time.deltaTime * 80;
                Vector3 pos = SplineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Position, pathShowingProgress);
                LastPosition= new Vector3(pos.x, GameController.Instance.CameraController.transform.position.y, pos.z);
                GameController.Instance.CameraController.transform.position = LastPosition;
            }
            else
            {
                if (homeCameraLerp < 1)
                {
                    homeCameraLerp += Time.deltaTime;
                    GameController.Instance.CameraController.transform.position = Vector3.Lerp(LastPosition, firstCameraPos, homeCameraLerp);
                }
                else { 
                GameController.Instance.PathShowInProgress = false;
                }
               
            }
       

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
        Vector3 pos = SplineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Position, 0);
         
        GameController.Instance.CameraController.transform.position= new Vector3(pos.x, GameController.Instance.CameraController.transform.position.y, pos.z);
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