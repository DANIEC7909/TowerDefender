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
    public float UnitSpeed;

    protected void Init(BGCcMath SplineMath)
    {
        currentSplineMathComponent = SplineMath;
        CurveDistance = currentSplineMathComponent.GetDistance();
        GameController.Instance.CurrentLevelScript.EnemiesOnLevel.Add(this);
    }
  protected void KillUnit()
    {
        GameController.Instance.CurrentLevelScript.EnemiesOnLevel.Remove(this);
        Destroy(gameObject);
    }
    protected void MoveBySpline(float speed)
    {
        if (ActualCurveDistance < CurveDistance)
        {
          

            ActualCurveDistance += (speed*Time.deltaTime);
            if (ActualCurveDistance >= CurveDistance)
            {
                ActualCurveDistance = 0;
            }
          transform.position=  currentSplineMathComponent.CalcPositionByDistance(ActualCurveDistance)+new Vector3(0,2);
        }
    }
    protected void Attack()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
     
        if (other.transform.CompareTag("Projectile"))
        {
            KillUnit();
            Destroy(other.gameObject);
        }
    }
}
