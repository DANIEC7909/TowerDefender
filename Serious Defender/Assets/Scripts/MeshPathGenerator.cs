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
    [SerializeField] Mesh MeshToSegmentate;
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
        
        float localDistance=SplineDistance;
        float calculatedResolution = SplineDistance / Resolution;
        for(float dist=0;dist<SplineDistance;dist+=calculatedResolution)
        {
            Vector3 PosByDistance = SplineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Position, dist);
        
           foreach(Vector3 pos in MeshToSegmentate.vertices)
            {
             VertexList.Add(pos+PosByDistance);
            }
           for( int i=0; i < VertexList.Count; i++)
            {
             //   MeshToSegmentate.triangles
            }
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