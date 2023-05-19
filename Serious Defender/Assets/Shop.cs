using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] RectTransform TurretsList;
    [SerializeField] Button TurretButton; 
    public void ShowTurrets()
    {
        foreach(TurretBase tb in GameController.Instance.Turrets)
        {
           Button btn = Instantiate(TurretButton, TurretsList);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = tb.name;
            btn.onClick.AddListener(() => SelectTurret(tb.TurretObject.ID));
        }
    }
    public void SelectTurret(int id)
    {
        Debug.Log("To jest wie¿yczka" + id + "");
        GameEvents.OnbuildingModeChanged_c(true);
        GameController.Instance.BuildController.TurretID = id;
    }
    
}
