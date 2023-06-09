using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] RectTransform TurretsList;
    [SerializeField] Button TurretButton;
    [SerializeField] List<GameObject> TurretsButtons = new List<GameObject>();
    public void ShowTurrets()
    {
        foreach (TurretBase tb in GameController.Instance.Turrets)
        {
            Button btn = Instantiate(TurretButton, TurretsList);
            if (tb.TurretObject.ButtonIMG)
            {
                btn.GetComponent<Image>().sprite = tb.TurretObject.ButtonIMG;
            }
            //btn.GetComponentInChildren<TextMeshProUGUI>().text = tb.name;
            btn.onClick.AddListener(() => SelectTurret(tb.TurretObject.ID));
            TurretsButtons.Add(btn.gameObject);
        }
    }
    public void SelectTurret(int id)
    {
        GameEvents.OnbuildingModeChanged_c(true);
        GameController.Instance.BuildController.TurretID = id;
    }
    public void ClearContailer()
    {

        foreach (GameObject rt in TurretsButtons)
        {
            Destroy(rt);
        }
    }
}
