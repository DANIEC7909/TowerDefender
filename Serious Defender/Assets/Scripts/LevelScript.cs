using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
public class LevelScript : MonoBehaviour
{
    [SerializeField] BGCcMath SplineMath;
    public List<EnemyBase> EnemiesOnLevel = new List<EnemyBase>(); 
    void Start()
    {
        if (SplineMath != null)
        {
            GameController.Instance.CurrentLevelSpline = SplineMath;
        }
        GameController.Instance.CurrentLevelScript = this;
    }
}
