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
    public int Damage=5;
    public Animator anim;
    int diedHash;
    public int MoneyIncreesement;
    protected void Init(BGCcMath SplineMath)
    {
        currentSplineMathComponent = SplineMath;
        CurveDistance = currentSplineMathComponent.GetDistance();
        GameController.Instance.CurrentLevelScript.EnemiesOnLevel.Add(this);
       // diedHash = Animator.StringToHash("Died");
    }
    public void DealDamage(int dmg)
    {
        Health -= dmg;
    }
    public void Tick()
    {
        MoveBySpline(UnitSpeed);
        if (Health <= 0)
        {
            KillUnit();
        }
    }
    public void Died()
    {
        Destroy(gameObject);
    }
    protected void KillUnit()
    {
        GameController.Instance.CurrentLevelScript.EnemiesOnLevel.Remove(this);
        GameController.Instance.Money += MoneyIncreesement;
        Died();
        //  anim.SetTrigger(diedHash); 
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
        if (other.transform.CompareTag("PlayerGoal"))
        {
            GameController.Instance.AddDamage(Damage);
        }
    }
    /* private void OnTriggerEnter(Collider other)
     {

         if (other.transform.CompareTag("Projectile"))
         {
             KillUnit();
             Destroy(other.gameObject);
         }
     }*/
}
