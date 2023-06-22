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


    public delegate void MusicStateChanged(MusicState state);
    public static event MusicStateChanged OnMusicStateChanged;
    public static void OnMusicStateChanged_c(MusicState state)
    {
        OnMusicStateChanged?.Invoke(state);
    }
    public delegate void FadeScreenIN();
    public static event FadeScreenIN OnFadeScreenIN;
    public static void FadeScreenIN_c()
    {
        OnFadeScreenIN?.Invoke();
    }

    public delegate void FadeScreenScreenCoverd();
    public static event FadeScreenIN OnFadeScreenScreenCoverd;
    public static void FadeScreenScreenCoverd_c()
    {
        OnFadeScreenScreenCoverd?.Invoke();
    }

    public delegate void FadeScreenOUT();
    public static event FadeScreenIN OnFadeScreenOUT;
    public static void FadeScreenOUT_c()
    {
        OnFadeScreenOUT?.Invoke();
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
    public delegate void BuildingPlaced();
    public static event BuildingPlaced OnBuildingPlaced;
    public static void OnBuildingPlaced_c()
    {
        OnBuildingPlaced?.Invoke();
    }
    public delegate void LevelLoaded(Scene scene);
    public static event LevelLoaded OnLevelLoaded;
    public static void OnLevelLoaded_c(Scene scene)
    {
        OnLevelLoaded?.Invoke(scene);
    }

    public delegate void Missle();
    public static event Missle OnMissle;
    public static void OnMissle_c()
    {
        OnMissle?.Invoke();
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
