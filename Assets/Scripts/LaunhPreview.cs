using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunhPreview : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private Vector3 dragStartPosition;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetStartPoint(Vector3 worldPoint)
    {
        dragStartPosition = worldPoint;
        lineRenderer?.SetPosition(0,dragStartPosition);
    }

    public void SetEndPoint(Vector3 worldPoint)
    {
        Vector3 pointOffset = worldPoint - dragStartPosition;
        Vector3 endPoint = transform.position + pointOffset;
        
        lineRenderer?.SetPosition(1,endPoint);
    }
}
