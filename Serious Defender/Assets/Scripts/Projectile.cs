using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public Vector3 Direction;
    public float Speed;
    [SerializeField] string AttackTag;

    void FixedUpdate()
    {
        rb.AddForce(Direction * Speed);
    }
    public void Start()
    {
        Destroy(gameObject, 5);     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(AttackTag))
        {
            Debug.Log("hit");
        }
    }
}
