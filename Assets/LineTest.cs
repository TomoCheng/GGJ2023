using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTest : MonoBehaviour
{
    public LineObj tttt;

    public Vector3 StartV3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartV3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 NowV3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(StartV3, NowV3) > 1)
            {
                StartV3 = NowV3;
                AddNewPots(StartV3);
            }
        }
    }

    void AddNewPots(Vector3 Pot)
    {
        tttt.lineRenderer.positionCount++;
        tttt.lineRenderer.SetPosition(tttt.lineRenderer.positionCount - 1, Pot);
    }
}