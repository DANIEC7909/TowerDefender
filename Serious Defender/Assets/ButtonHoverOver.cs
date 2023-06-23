using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameController.Instance.IsPointerOverUI = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameController.Instance.IsPointerOverUI = false;
    }
}
