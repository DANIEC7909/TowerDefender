using UnityEngine;
using System.Collections.Generic;

public class PiramidTurret : TurretBase
{
   public float DistanceToBuffedTurrets;
   public List<TurretBase> BuffedTurrets = new List<TurretBase>();
    private void OnEnable()
    {
        GameEvents.OnBuildingPlaced += CalculateAndBuffSurroundingTurrets;
    }
    private void Start()
    {
        CalculateAndBuffSurroundingTurrets();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, DistanceToBuffedTurrets);
    }
    private void CalculateAndBuffSurroundingTurrets()
    {
        foreach (TurretBase tb in GameController.Instance.CurrentLevelScript.TurretPlacedInLevel)
        {
            if (UnityEngine.Vector3.Distance(transform.position,tb.transform.position)<DistanceToBuffedTurrets)
            {
                BuffUp(tb);
            }
        }
    }
    public void BuffUp(TurretBase turretBase)
    {
        if (turretBase.BuffedBy == null)
        {
            turretBase.BuffedBy = this;
            BuffedTurrets.Add(turretBase);
            turretBase.ShootingCooldown -= 0.05f;
            turretBase.Projectile.Damage += 5;
        }
    }
    private void OnDestroy()
    {
        GameEvents.OnBuildingPlaced -= CalculateAndBuffSurroundingTurrets;
    }
}
