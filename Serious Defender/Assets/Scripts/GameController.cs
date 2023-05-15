using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline;
public class GameController : Singleton
{
   public BansheeGz.BGSpline.Components.BGCcMath CurrentLevelSpline;
    public static GameController Instance;
    void Start()
    {
        Init();
        Instance = this;
    }

}
