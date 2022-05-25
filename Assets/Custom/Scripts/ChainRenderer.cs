using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainRenderer : MonoBehaviour
{
    private LineRenderer lr;
    public Transform[] Points;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetupLine(Transform[] points)
    {
        lr.positionCount = points.Length;
        this.Points = points;
    }

    void LateUpdate()
    {
        for (int i = 0; i < Points.Length; i++)
        {
            lr.SetPosition(i, Points[i].position);
        }
    }
}
