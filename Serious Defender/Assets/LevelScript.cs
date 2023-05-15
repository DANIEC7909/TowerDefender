using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
public class LevelScript : MonoBehaviour
{
    [SerializeField] BGCcMath SplineMath;
    void Start()
    {
        if (SplineMath != null)
        {
            GameController.Instance.CurrentLevelSpline = SplineMath;
        }
    }
}
