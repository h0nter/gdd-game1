using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UV_red : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector2[] UVs = new Vector2[mesh.vertices.Length];
        // Front
        UVs[0] = Vector2.zero;
        UVs[1] = Vector2.zero;
        UVs[2] = Vector2.zero;
        UVs[3] = Vector2.zero;
        // Top
        UVs[4] = new Vector2(0.334f, 0.333f);
        UVs[5] = new Vector2(0.666f, 0.333f);
        UVs[8] = new Vector2(0.334f, 0.0f);
        UVs[9] = new Vector2(0.666f, 0.0f);
        // Back
        UVs[6] = Vector2.zero;
        UVs[7] = Vector2.zero;
        UVs[10] = Vector2.zero;
        UVs[11] = Vector2.zero;
        // Bottom
        UVs[12] = new Vector2(0.0f, 0.334f);
        UVs[13] = new Vector2(0.0f, 0.666f);
        UVs[14] = new Vector2(0.333f, 0.666f);
        UVs[15] = new Vector2(0.333f, 0.334f);
        // Left
        UVs[16] = Vector2.zero;
        UVs[17] = Vector2.zero;
        UVs[18] = Vector2.zero;
        UVs[19] = Vector2.zero;
        // Right        
        UVs[20] = Vector2.zero;
        UVs[21] = Vector2.zero;
        UVs[22] = Vector2.zero;
        UVs[23] = Vector2.zero;
        mesh.uv = UVs;
    }
}
