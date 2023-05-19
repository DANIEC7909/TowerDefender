using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnBuildMode : MonoBehaviour
{
    public MeshRenderer MeshRenderer;
    private void OnEnable()
    {
        GameEvents.OnBuildingModeChanged += GameEvents_OnBuildingModeChanged;
    }

    private void GameEvents_OnBuildingModeChanged(bool state)
    {
        MeshRenderer.enabled = state;

    }

    private void OnDisable()
    {
        GameEvents.OnBuildingModeChanged -= GameEvents_OnBuildingModeChanged;
    }
}
