using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float Speed = 3;
    
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal")*Time.deltaTime*Speed, 0, Input.GetAxis("Vertical")*Time.unscaledTime*Speed);
       
    }
    private void OnEnable()
    {
        GameEvents.OnGameControllerInit += SetReference;
    }
    private void OnDisable()
    {
        GameEvents.OnGameControllerInit -= SetReference;
    }
    private void SetReference()
    {
        GameController.Instance.CameraController = this;
    }
    public void SetCameraOnEnemy()
    {
      
            transform.position = new Vector3(GameController.Instance.CurrentLevelScript.EnemySpawner.position.x, transform.position.y, GameController.Instance.CurrentLevelScript.EnemySpawner.position.z);
    }

}
