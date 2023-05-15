using UnityEngine;

public class GameEvents : Singleton
{
    public static GameEvents Instance;
    private void Start()
    {
        Init();
        Instance = this;
    }
}
