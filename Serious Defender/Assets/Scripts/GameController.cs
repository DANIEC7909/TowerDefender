using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : Singleton
{
    public LevelScript CurrentLevelScript;
   public BansheeGz.BGSpline.Components.BGCcMath CurrentLevelSpline;
    public static GameController Instance;
    void Start()
    {
        Init();
        Instance = this;
    }

}
