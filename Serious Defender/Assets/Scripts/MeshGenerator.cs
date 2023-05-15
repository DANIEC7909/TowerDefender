using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Curve;
using BansheeGz.BGSpline.Components;

public class MeshGenerator : MonoBehaviour
{
    [SerializeField] BGCcMath splineMath;
    [SerializeField] float SplineDistance;
    [SerializeField] float localDistnace;
    [SerializeField] GameObject Ghost;
    void Start()
    {
        Ghost = GameObject.CreatePrimitive(PrimitiveType.Cube);
        splineMath = GetComponent<BGCcMath>();
        SplineDistance = splineMath.GetDistance();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (localDistnace > SplineDistance)
        {
            localDistnace = 0;
        }
        localDistnace += Time.unscaledDeltaTime * 5;
        
      Ghost.transform.position=splineMath.CalcByDistance(BGCurveBaseMath.Field.Position, localDistnace);
        Ghost.transform.rotation = Quaternion.LookRotation(splineMath.CalcByDistance(BGCurveBaseMath.Field.Tangent,localDistnace));
    }
}
