using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;

public abstract class EnemyBase : MonoBehaviour
{
    public BGCcMath currentSplineMathComponent;
    public float CurveDistance;
    public float ActualCurveDistance;
    public float Health;
    public bool CanAttackTowers;
    protected void InitilizeCurve(BGCcMath SplineMath)
    {
        currentSplineMathComponent = SplineMath;
        CurveDistance = currentSplineMathComponent.GetDistance();

    }

    protected void MoveBySpline(float speed)
    {
        if (ActualCurveDistance < CurveDistance)
        {
            ActualCurveDistance += (speed*Time.deltaTime);
            currentSplineMathComponent.CalcPositionByDistance(ActualCurveDistance);
        }
    }
    protected void Attack()
    {

    }
}
