using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public Vector3 Direction;
    public float Speed;

    void FixedUpdate()
    {
        rb.AddForce(Direction * Speed);
    }
    public void Start()
    {
        Destroy(gameObject, 5);     
    }
   
}
