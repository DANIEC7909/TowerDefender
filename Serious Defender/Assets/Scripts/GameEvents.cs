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


    private void Start()
    {
        Init();
        Instance = this;
    }
}
