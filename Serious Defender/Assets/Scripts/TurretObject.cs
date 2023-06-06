using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurretData", menuName = "Turret/TurretData", order = 0)]
public class TurretObject : ScriptableObject
{
    public int Price;
    public int Health;
    public int Damage;
    public float ShootCoolDown;
    public float AttackRange;
    public Projectile Projectile;
    public int ID;
    public Sprite ButtonIMG;
}
