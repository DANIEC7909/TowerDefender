using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCamera : MonoBehaviour
{
    public Transform cam;
    public void Start()
    {
        cam = GameController.Instance.CameraController.transform;
    }
    void Update()
    {
        transform.rotation = Quaternion.LookRotation((cam.position - transform.position).normalized);
    }
}
