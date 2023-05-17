using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using UnityEditor;

public class GeneratePlaceFields : MonoBehaviour
{
    [SerializeField] BGCcMath splineMath;
    [SerializeField] float SplineDistance;
    [SerializeField] int Ratio;
    [SerializeField] float calculatedDistance;
    [SerializeField] GameObject PlaceField;
    [SerializeField] float displacement;
    [SerializeField] List<GameObject> PfList = new List<GameObject>();
    public void GeneratePlacementFields()
    {
        SplineDistance = splineMath.GetDistance();
        calculatedDistance = SplineDistance / Ratio;
;        for(float dist = 0; dist < SplineDistance; dist += calculatedDistance)
        {
          Vector3 pos=  splineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Position, dist);

            Vector3 calcPos = pos+Quaternion.LookRotation(splineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Tangent,dist))*(Vector3.right* displacement);

            PfList.Add( Instantiate(PlaceField,calcPos , Quaternion.identity));

            Vector3 calcPosLeft = pos + Quaternion.LookRotation(splineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Tangent, dist)) * (-Vector3.right * displacement);

            PfList.Add( Instantiate(PlaceField, calcPosLeft, Quaternion.identity));
        }
    }
    public void RemoveAllPlaceFields()
    {
        foreach(GameObject go in PfList)
        {
            DestroyImmediate(go);
        }
        PfList.Clear();
    } 
}

[CustomEditor(typeof(GeneratePlaceFields), true)]
public class GeneratePlaceFieldsed : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GeneratePlaceFields GPF = (GeneratePlaceFields)target;
        if (GUILayout.Button("GeneratePlaceField"))
        {
            GPF.GeneratePlacementFields();
        }
        if (GUILayout.Button("REmove all PlaceFields"))
        {
            GPF.RemoveAllPlaceFields();
        }
    }
}