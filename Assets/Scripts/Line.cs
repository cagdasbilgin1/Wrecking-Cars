using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] Transform target;
    LineRenderer lineRender;

    void Start()
    {
        lineRender = GetComponent<LineRenderer>();
    }


    void Update()
    {
        DrawLine();
    }

    void DrawLine()
    {
        if (target)
        {
            lineRender.positionCount = 2;
            lineRender.SetPosition(0, target.position);
            lineRender.SetPosition(1, transform.position);
        }        
    }
}
