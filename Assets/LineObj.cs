using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineObj : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public List<Vector3> Pots;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3[] v3s = new Vector3[100];
        //Pots = new List<Vector3>();
        //for (int i = 0; i < lineRenderer.GetPositions(v3s); i++)
        //{
        //    Pots.Add(v3s[i] - transform.position);
        //}
        Vector3 v3 = transform.position + Vector3.zero;
        v3.z = 0;
        lineRenderer.SetPosition(0, v3);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Pots == null) return;
        //lineRenderer.positionCount = Pots.Count;
        //for (int i = 0; i < Pots.Count; i++)
        //{
        //    Vector3 v3 = Pots[i] + transform.position;
        //    v3.z = 0;
        //    lineRenderer.SetPosition(i, v3);
        //}
        //print(v3s.Length);
        //lineRenderer.SetPositions(v3s);
    }
}
