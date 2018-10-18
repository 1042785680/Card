using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    private Rigidbody rb;

    private MeshFilter mf;

    private bool isFront;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        mf = gameObject.GetComponent<MeshFilter>();
    }

    private void FixedUpdate()
    {
        AddForceToCard();
    }

    private void AddForceToCard()
    {
        GameObject ForceBall = GameObject.FindGameObjectWithTag("Force");
        if (!ForceBall)
            return;
        Vector3[] vertices = mf.mesh.vertices;
        foreach (Vector3 vertex in vertices)
        {
            Vector3 vertexWorld = transform.TransformPoint(vertex);
            Vector3 vec = vertexWorld - ForceBall.transform.position;
            ForceAttrbution fa = ForceBall.gameObject.GetComponent<ForceAttrbution>();
            float forceMagnitudeOnSource = fa.forceMagnitude;
            float distance = vec.magnitude;
            float forceMagnitudeOnVertex = fa.ForceAttenuation(forceMagnitudeOnSource, distance);
            Vector3 forceOnVertex = vec.normalized * forceMagnitudeOnVertex;
            rb.AddForceAtPosition(forceOnVertex, vertexWorld);
        }
    }

}

