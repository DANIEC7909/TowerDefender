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

    void FixedUpdate()
    {
        rb.AddForce(Direction * Speed);
    }
    public void Start()
    {
        Destroy(gameObject, 5);     
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.transform.CompareTag(AttackTag))
        {
            other.transform.GetComponent<EnemyBase>().DealDamage(Damage);
            Debug.Log("Enemy hit");
        }
    }
}
