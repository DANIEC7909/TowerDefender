using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public Vector3 Direction;
    public float Speed;
    [SerializeField] string AttackTag;
    public int Damage;
    public Transform target;
    void FixedUpdate()
    {
        rb.AddForce(Direction * Speed);
        transform.LookAt(target);
    }
    public void Start()
    {
        Destroy(gameObject, 3);     
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.transform.CompareTag(AttackTag))
        {
            other.transform.GetComponent<EnemyBase>().DealDamage(Damage);
          
        }
    }
}
