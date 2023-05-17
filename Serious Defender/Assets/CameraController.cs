using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float Speed = 3;
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal")*Time.deltaTime*Speed, 0, Input.GetAxis("Vertical")*Time.deltaTime*Speed);
       
    }
}
