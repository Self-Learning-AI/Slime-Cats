using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyPhysics : MonoBehaviour
{
    public static JellyPhysics Instance;
    public GameObject[] Bones;
    public Vector3 Center;

    public SkinnedMeshRenderer SMRenderer;
    public Mesh jellyBakedMesh;

    Vector3 velocity;


    void Awake()
    {
        Instance = this;
    }


    void FixedUpdate()
    {
        // Get sum of all bones
        for(int i = 0; i < Bones.Length; i++)
        {
            Center += Bones[i].transform.position;
        }
        // Get the average position of all bones
        Center = Center / Bones.Length;
        // New position is the center point between all bones
        transform.position = Center;

        Center = Vector3.zero;

        JellyBakeMeshToCollider();
    }

    void JellyBakeMeshToCollider()
    {
        SMRenderer.BakeMesh(jellyBakedMesh);
        gameObject.GetComponent<MeshCollider>().sharedMesh = jellyBakedMesh;
    }
}
