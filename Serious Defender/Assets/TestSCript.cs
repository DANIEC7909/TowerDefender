using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSCript : MonoBehaviour
{
  [SerializeField]  float cAxisMoveY, cUnitSpeedX;
  [SerializeField]  float AxisMoveY, UnitSpeedX;
   void Update()
    {
        float k = cAxisMoveY / cUnitSpeedX;
        AxisMoveY = k * UnitSpeedX;
        Debug.Log(AxisMoveY);
    }
}
