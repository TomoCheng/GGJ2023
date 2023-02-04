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
        Vector3[] v3s = new Vector3[100];
        Pots = new List<Vector3>();
        for (int i = 0; i < lineRenderer.GetPositions(v3s); i++)
        {
            Pots.Add(transform.position - v3s[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Pots == null) return;
        Vector3[] v3s = new Vector3[Pots.Count];
        for (int i = 0; i < Pots.Count; i++)
        {
            v3s[i] = Pots[i] + transform.position;
        }
        lineRenderer.SetPositions(v3s);
    }
}
