using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour
{
    public TurretObject TurretObject;
    public int Health;
    public float ShootingCooldown;
    private float localShootingCooldown;
    public int Damage;
    public float AtackRange;
    public EnemyBase Target;
    public bool IsActive;
    public Projectile Projectile;
    public Transform TurretHead;
    public Transform TurretMuzzle;
    public Animator Animator;
    public float AxisMove;
    public void ObtainTarget()
    {
        int id = -1;
        float lastDistance = 9999;
        List<EnemyBase> EnemiesInRange = new List<EnemyBase>();
        EnemyBase LocalTarget = new EnemyBase();
        foreach (EnemyBase eb in GameController.Instance.CurrentLevelScript.EnemiesOnLevel)
        {
            if (eb == null)
            {
                id = GameController.Instance.CurrentLevelScript.EnemiesOnLevel.IndexOf(eb);
            }
            else
            {


                if (Vector3.Distance(transform.position, eb.transform.position) < AtackRange)
                {
                    EnemiesInRange.Add(eb);
                }
            }
        }
        if (id != -1)
        {
            GameController.Instance.CurrentLevelScript.EnemiesOnLevel.RemoveAt(id);
        }
        foreach (EnemyBase eb in EnemiesInRange)
        {
            if (Vector3.Distance(transform.position, eb.transform.position) < lastDistance)
            {
                lastDistance = Vector3.Distance(transform.position, eb.transform.position);
                LocalTarget = eb;
            }
        }
        Target = LocalTarget;
    }
    public void Shoot()
    {
        Projectile lp = Instantiate(Projectile, TurretMuzzle.position, Quaternion.identity);
        lp.Direction = TurretMuzzle.forward;
        if (Animator != null)
        {
            Animator.SetTrigger("Shoot");
        }
    }
    public void Start()
    {
        Health = TurretObject.Health;
        Damage = TurretObject.Damage;
        ShootingCooldown = TurretObject.ShootCoolDown;
        ShootingCooldown = TurretObject.ShootCoolDown;
        AtackRange = TurretObject.AttackRange;
        Projectile = TurretObject.Projectile;
    }
    public void Update()
    {
        if (Target == null)
        {
            ObtainTarget();
        }
        else
        {
            if (Vector3.Distance(transform.position, Target.transform.position) > AtackRange)
            {
                ObtainTarget();
            }
       
       
            if (IsActive)
            {
                Vector3 pos =Target.currentSplineMathComponent.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Position, Target.ActualCurveDistance + AxisMove);
                Vector3 pos2 = new Vector3(pos.x, Target.transform.position.y, pos.z);
                TurretHead.LookAt(pos2);

                localShootingCooldown += Time.deltaTime;
                if (localShootingCooldown > ShootingCooldown)
                {
                    Shoot();
                    localShootingCooldown = 0;
                }
            }
        }
        //shoot projetile;
    }
}
