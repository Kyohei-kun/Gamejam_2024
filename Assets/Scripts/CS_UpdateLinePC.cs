using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_UpdateLinePC : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;

    [SerializeField] Transform pc;
    [SerializeField] Transform jack;

    Vector3[] positions = new Vector3[2];

    void Update()
    {
        positions[0] = pc.position;
        positions[1] = jack.position;

        lineRenderer.SetPositions(positions);
    }
}
