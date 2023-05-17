using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;

public  class EnemyBase : MonoBehaviour
{
    public BGCcMath currentSplineMathComponent;
    public float CurveDistance;
    public float ActualCurveDistance;
    public float Health;
    public bool CanAttackTowers;
    public float ActualUnitSpeed;
    protected void Init(BGCcMath SplineMath)
    {
        currentSplineMathComponent = SplineMath;
        CurveDistance = currentSplineMathComponent.GetDistance();
        GameController.Instance.CurrentLevelScript.EnemiesOnLevel.Add(this);
    }
  
    protected void MoveBySpline(float speed)
    {
        if (ActualCurveDistance < CurveDistance)
        {
            ActualUnitSpeed = (speed * Time.deltaTime);

            ActualCurveDistance += (speed*Time.deltaTime);
            if (ActualCurveDistance >= CurveDistance)
            {
                ActualCurveDistance = 0;
            }
            currentSplineMathComponent.CalcPositionByDistance(ActualCurveDistance);
        }
    }
    protected void Attack()
    {

    }
}
