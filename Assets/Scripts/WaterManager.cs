using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// anything attached to this script MUST have these components
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaterManager : MonoBehaviour
{
    private MeshFilter meshFilter;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        // create an array that store this meshFilters verticies (used to render the shape)
        Vector3[] vertices = meshFilter.mesh.vertices;

        // loop through verticies array setting each verticie equal to waveManager's vertices
        for(int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = WaveManager.instance.GetWaveHeightAtX(transform.position.x + vertices[i].x);
        }

        // assign the verticies to the mesh
        meshFilter.mesh.vertices = vertices;
        //make sure mesh normals are correct
        meshFilter.mesh.RecalculateNormals();
    }
}
