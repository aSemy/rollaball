using UnityEngine;
using UnityEditor;

public class CurvedGroundEditor : Editor
{
    [MenuItem("GameObject/Create Other/Grid")]
    static void Create()
    {
        GameObject gameObject = new GameObject("Grid");
        Grid s = gameObject.AddComponent<Grid>();
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        meshFilter.mesh = new Mesh();
        s.AwakeEditor();
    }
}