using BansheeGz.BGSpline.Components;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GeneratePlaceFields : MonoBehaviour
{
    [SerializeField] BGCcMath splineMath;
    [SerializeField] float SplineDistance;
    [SerializeField] int Ratio;
    [SerializeField] float calculatedDistance;
    [SerializeField] GameObject PlaceField;
    [SerializeField] float displacement;
    [SerializeField] List<GameObject> PfList = new List<GameObject>();

    [Header("PathMesh")]
    [SerializeField] Mesh meshToSegmentatekri;

    public void GeneratePlacementFields()
    {
        SplineDistance = splineMath.GetDistance();
        calculatedDistance = SplineDistance / Ratio;
        ; for (float dist = 0; dist < SplineDistance; dist += calculatedDistance)
        {
            Vector3 pos = splineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Position, dist);

            Vector3 calcPos = pos + Quaternion.LookRotation(splineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Tangent, dist)) * (Vector3.right * displacement);

            PfList.Add(Instantiate(PlaceField, calcPos, Quaternion.identity));

            Vector3 calcPosLeft = pos + Quaternion.LookRotation(splineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Tangent, dist)) * (-Vector3.right * displacement);

            PfList.Add(Instantiate(PlaceField, calcPosLeft, Quaternion.identity));
        }
    }
    public void RemoveAllPlaceFields()
    {
        foreach (GameObject go in PfList)
        {
            DestroyImmediate(go);
        }
        PfList.Clear();
    }

    [SerializeField] List<Vector3> SplineVertex = new List<Vector3>();
    [SerializeField] List<Vector3> Vertexes = new List<Vector3>();
    [SerializeField] int vertIndex;
    [SerializeField] int TriIndex;
    public void GeneratePath()
    {
        vertIndex = 0;
        TriIndex = 0;
        SplineVertex.Clear();
        Vertexes.Clear();

        Mesh PathMesh = new Mesh();

        SplineDistance = splineMath.GetDistance();
        calculatedDistance = SplineDistance / Ratio;



        for (float dist = 0; dist < SplineDistance; dist += calculatedDistance)
        {
           SplineVertex.Add(splineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Position, dist));
        }

        //generate vertex 
        for (float dist = 0; dist < SplineDistance; dist += calculatedDistance)
        {
            Vector3 pos = splineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Position, dist);

            Vector3 pos1 = pos + Quaternion.LookRotation(splineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Tangent, dist)) * (Vector3.right * 3);
            Vertexes.Add(pos1);

            Vector3 pos2 = pos + Quaternion.LookRotation(splineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Tangent, dist)) * (-Vector3.right * 3);
            Vertexes.Add(pos2);


        }
        int[] Tris = new int[2 * (SplineVertex.Count - 1) * 3];
    Vector2[] uvs = new Vector2[Vertexes.Count];
        for(int i =0; i < SplineVertex.Count;i++)
        {
           
                float completionPercent = i / (float)(SplineVertex.Count - 1);
                uvs[vertIndex] = new Vector2(0, completionPercent);
                uvs[vertIndex + 1] = new Vector2(1, completionPercent);
           
            if (i < SplineVertex.Count - 1)
            {
                Tris[TriIndex] = vertIndex;
                Tris[TriIndex+1] = vertIndex+2;
                Tris[TriIndex+2 ] = vertIndex+1;

                Tris[TriIndex+3] = vertIndex+1;
                Tris[TriIndex+4] = vertIndex+2;
                Tris[TriIndex+5] = vertIndex+3;
            }
            vertIndex += 2;
            TriIndex += 6;
        }
        PathMesh.vertices = Vertexes.ToArray();
       PathMesh.triangles = Tris;
        PathMesh.uv = uvs;
        //   PathMesh.SetTriangles(Tris, 0);
        PathMesh.RecalculateNormals();
        GameObject PathGo = new GameObject("TEST-PATH");
        PathGo.AddComponent<MeshFilter>().mesh = PathMesh;
        PathGo.AddComponent<MeshRenderer>();

        PathGo.transform.position += new Vector3(0, .13f);
        /*
                //generate vertex 
                for (float dist = 0; dist < SplineDistance; dist += calculatedDistance)
                {
                    Vector3 pos = splineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Position, dist);

                    Vector3 pos1 = pos + Quaternion.LookRotation(splineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Tangent, dist)) * (Vector3.right * 3);
                    Vertexes.Add(pos1);

                    Vector3 pos2 = pos + Quaternion.LookRotation(splineMath.CalcByDistance(BansheeGz.BGSpline.Curve.BGCurveBaseMath.Field.Tangent, dist)) * (-Vector3.right * 3);
                    Vertexes.Add(pos2);


                }

                int[] Triangles = new int[2 * ((Vertexes.Count / 2) - 1) * 3];
                int iterator = 0;
                for (float dist = 0; dist < SplineDistance; dist += calculatedDistance)
                {
                    try
                    {
                        if (iterator < ((Vertexes.Count / 2) - 1))
                            Triangles[TriIndex] = vertIndex;
                        Triangles[TriIndex + 1] = vertIndex + 2;
                        Triangles[TriIndex + 2] = vertIndex + 1;

                        Triangles[TriIndex + 3] = vertIndex + 1;
                        Triangles[TriIndex + 4] = vertIndex + 2;
                        Triangles[TriIndex + 5] = vertIndex + 3;

                        TriIndex += 6;
                        vertIndex += 2;
                        iterator++;
                    }
                    catch { }      
                    }

                Mesh pathf = new Mesh();
                pathf.triangles = Triangles;
                pathf.vertices = Vertexes.ToArray();
                GameObject PathGo = new GameObject("TEST-PATH");
                PathGo.AddComponent<MeshFilter>().mesh = pathf;*/
    }
}
#if UNITY_EDITOR
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

        if (GUILayout.Button("GeneratePath"))
        {
            GPF.GeneratePath();
        }

    }
}
#endif