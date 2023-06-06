using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents : Singleton
{
    public static GameEvents Instance;

    public delegate void BuildModeChanged(bool state);
    public static event BuildModeChanged OnBuildingModeChanged;
    public static void OnbuildingModeChanged_c(bool state)
    {
        OnBuildingModeChanged?.Invoke(state);
    }


    public delegate void MusicStateChanged(MusicState state,AudioClip clip=null);
    public static event MusicStateChanged OnMusicStateChanged;
    public static void OnMusicStateChanged_c(MusicState state,AudioClip clip =null)
    {
        OnMusicStateChanged?.Invoke(state, clip);
    }

    public delegate void LoadNextLevel();
    public static event LoadNextLevel OnLoadNextLevel;
    public static void OnLoadNextLevel_c()
    {
        OnLoadNextLevel?.Invoke();
    }
    public delegate void GameControllerInit();
    public static event GameControllerInit OnGameControllerInit;
    public static void OnGameControllerInit_c()
    {
        OnGameControllerInit.Invoke();
    }
    public delegate void LevelLoaded(Scene scene);
    public static event LevelLoaded OnLevelLoaded;
    public static void OnLevelLoaded_c(Scene scene)
    {
        OnLevelLoaded?.Invoke(scene);
    }

    public delegate void NextWave();
    public static event NextWave OnNextWave;
    public static void OnNextWave_c()
    {
        OnNextWave?.Invoke();
    }
    public delegate void GameFailed();
    public static event GameFailed OnGameFailed;
    public static void OnGameFailed_c()
    {
        OnGameFailed?.Invoke();
    }

    public delegate void GameWin();
    public static event GameWin OnGameWin;
    public static void OnGameWin_c()
    {
        OnGameWin?.Invoke();
    }

    private void Start()
    {
        Init();
        Instance = this;
    }
}
