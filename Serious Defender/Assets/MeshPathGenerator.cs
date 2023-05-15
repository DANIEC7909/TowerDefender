using BansheeGz.BGSpline.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeshPathGenerator : MonoBehaviour
{
    [SerializeField] BGCcMath SplineMath;
    [SerializeField] float SplineDistance;
    [SerializeField] int Resolution = 10;
    public void GeneratePath()
    {
      SplineDistance=SplineMath.GetDistance();

        Debug.Log("<color=aqua>[MPG] "+SplineDistance+"</color>");
        GameObject newMeshPathGameObject = new GameObject("NewMeshPathGameObject");
       MeshRenderer Mr = newMeshPathGameObject.AddComponent<MeshRenderer>();
       MeshFilter   Mf = newMeshPathGameObject.AddComponent<MeshFilter>();

        Mesh MeshPath =new Mesh();
        List<Vector3> VertexList=new List<Vector3>();
        List<int> TrianglesList = new List<int>();
        VertexList.AddRange(new Vector3[] {new Vector3(0,0,0), new Vector3(1,0,0), new Vector3(0,1,0), new Vector3(1,1,0)});
        float localDistance=SplineDistance;
        float calculatedResolution = SplineDistance / Resolution;
        for(float dist=0;dist<SplineDistance;dist+=calculatedResolution)
        {
            Vector3 PosByDistance = SplineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Position, dist);
           
           VertexList.Add(PosByDistance + Vector3.right);
           VertexList.Add(PosByDistance - Vector3.right);
        }
        MeshPath.SetVertices(VertexList);
        MeshPath.SetTriangles(TrianglesList, 0);
        MeshPath.name = "MyTestMeshPath";
        MeshPath.uv = new Vector2[]{ new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(1, 1) };
        MeshPath.RecalculateNormals();
        Mf.mesh = MeshPath;
    }
  
}
[CustomEditor(typeof(MeshPathGenerator),true)]
public class MeshPathGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MeshPathGenerator mpg = (MeshPathGenerator)target;
        if (GUILayout.Button("GeneratePath"))
        {
            mpg.GeneratePath();
        }
    }
}