using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Manager : MonoBehaviour
{
    public LineObj MainLine;

    public Vector3 StartV3;

    public LineObj NowLine;

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
            if (Vector3.Distance(StartV3, NowV3) > 0.5f)
            {
                StartV3 = NowV3;
                NowLine.AddNewPots(StartV3);
            }
        }
    }

    public List<LineObj> GetAllLine()
    {
        List<LineObj> r = new List<LineObj>();
        MainLine.GetAllLine(r);

        return r;
    }
}
