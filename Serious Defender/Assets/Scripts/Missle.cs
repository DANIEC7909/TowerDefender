using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    [SerializeField] MisslePainVolume PainVolume;
    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                gameObject.SetActive(false);
                GameController.Instance.Money += 500;
            }
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = hit.point+Vector3.up;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                GameController.Instance.Money -= 500;
                Instantiate(PainVolume, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
            }
    }
}
