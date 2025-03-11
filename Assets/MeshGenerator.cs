using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    private Mesh mesh;
    
    private Vector3[] vertices;
    private int[] triangles;

    public int x = 20;
    public int z = 20;
    
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        CreateTerrainMesh();
        UpdateMesh();
    }

    void CreateTerrainMesh()
    {
        vertices = new Vector3[(x + 1) * (z + 1)];

        int index = 0;
        
        for (int j = 0; j <= z; j++)
        {
            for (int i = 0; i <= x; i++)
            {
                vertices[index] = new Vector3(i, 0, j);
                index++;
            }
        }

        triangles = new int[x * z * 6];
        int v = 0;
        int t = 0;
        
        for (int j = 0; j < z; j++)
        {
            for (int i = 0; i < x; i++)
            {
                triangles[t] = v;
                triangles[t + 1] = v + x + 1;
                triangles[t + 2] = v + 1;
                triangles[t + 3] = v + 1;
                triangles[t + 4] = v + x + 1;
                triangles[t + 5] = v + x + 2;

                v++;
                t += 6;
            }

            v++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}