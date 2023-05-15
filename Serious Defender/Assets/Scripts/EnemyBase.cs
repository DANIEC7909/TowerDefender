using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right;
        }
    }
}
