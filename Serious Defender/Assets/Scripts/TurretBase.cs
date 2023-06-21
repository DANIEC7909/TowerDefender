using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour
{

    public TurretObject TurretObject;
    public int Health;
    public float ShootingCooldown;
    private float localShootingCooldown;
    public float Damage;
    public float AtackRange;
    public EnemyBase Target;
    public bool IsActive;
    public Projectile Projectile;

    public bool IsInited { get; private set; }

    public Transform TurretHead;
    public Transform TurretMuzzle;
    public Animator Animator;
    public float AxisMove;
    public float  ConstAxisMove = 1;
    public float ConstUnitSpeed = 3;
    public PiramidTurret BuffedBy;
    public GameObject LevelUpIcon;
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
            if (Vector3.Distance(transform.position, eb.transform.position) < lastDistance && eb.IsKilled==false)
            {
                lastDistance = Vector3.Distance(transform.position, eb.transform.position);
                LocalTarget = eb;
            }
        }
        Target = LocalTarget;

        float k = ConstAxisMove / ConstUnitSpeed;
        AxisMove = k * Target.UnitSpeed;
       Debug.Log(AxisMove);
    }
    public void Shoot()
    {
        Projectile lp = Instantiate(Projectile, TurretMuzzle.position, Quaternion.identity);
        lp.Direction = TurretMuzzle.forward;
        lp.Damage = Damage;
        lp.target = Target.transform;
        if (Animator != null)
        {
            Animator.SetTrigger("Shoot");
        }
    }
    protected void Init()
    {
        if (!IsInited)
        {
            Health = TurretObject.Health;
            Damage = TurretObject.Damage;
            ShootingCooldown = TurretObject.ShootCoolDown;
            ShootingCooldown = TurretObject.ShootCoolDown;
            AtackRange = TurretObject.AttackRange;
            Projectile = TurretObject.Projectile;
            IsInited = true;
        }
    }
    public void BuffEnemy()
    {
        Init();
        ShootingCooldown -=0.02f;
        Damage += (Projectile.Damage*1.1f);
        AtackRange += 5;
        LevelUpIcon.SetActive(true);
    }
    protected void Tick()
    {
        if (Target == null)
        {
            ObtainTarget();
        }
        else
        {

            if (Vector3.Distance(transform.position, Target.transform.position) > AtackRange|| Target.IsKilled)
            {
                ObtainTarget();
            }
       
       
            if (IsActive)
            {
                Vector3 pos =Target.currentSplineMathComponent.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Position, Target.ActualCurveDistance + AxisMove);
                Vector3 pos2 = new Vector3(pos.x, Target.transform.position.y, pos.z);
                TurretHead.LookAt(pos2+(Vector3.up*2));

                localShootingCooldown += Time.deltaTime;
                if (localShootingCooldown > ShootingCooldown)
                {
                       //shoot projetile;
                    Shoot();
                    localShootingCooldown = 0;
                }
            }
        }
    }
}
