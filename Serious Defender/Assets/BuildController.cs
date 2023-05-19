using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    [SerializeField] Camera cam;

    public int TurretID;
    private void Start()
    {
        cam = GetComponent<Camera>();
  
    }
    private void OnEnable()
    {
        GameEvents.OnLevelLoaded += GameEvents_OnLevelLoaded;
    }

    private void GameEvents_OnLevelLoaded(UnityEngine.SceneManagement.Scene scene)
    {
        if(String.Equals(scene.name,"Level1"))
        GameController.Instance.BuildController = this;
    }

    private void OnDisable()
    {
        GameEvents.OnLevelLoaded -= GameEvents_OnLevelLoaded;
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("PlaceField"))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    foreach (TurretBase tb in GameController.Instance.Turrets)
                    {
                        if (tb.TurretObject.ID == TurretID)
                        {
                            if (GameController.Instance.Money - tb.TurretObject.Price > 0)
                            {
                                Instantiate(tb, hit.transform.position, Quaternion.identity);
                                GameController.Instance.Money -= tb.TurretObject.Price;
                                GameEvents.OnbuildingModeChanged_c(false); 
                            }

                        }
                    }
                }
            }
        }
    }
}
