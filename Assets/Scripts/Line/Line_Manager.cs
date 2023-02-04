using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line_Manager : MonoBehaviour
{
    public static Line_Manager _;

    public LineObj LineObjPre;

    public LineObj MainLine;

    public Vector3 StartV3;

    public LineObj NowLine
    {
        get => _NowLine;
        set
        {
            //if (_NowLine != null) _NowLine.GetComponent<Image>().raycastTarget = false;
            _NowLine = value;
            if (_NowLine != null)
            {
                StartV3 = NowLine.lineRenderer.GetPosition(NowLine.lineRenderer.positionCount - 1);
                //_NowLine.GetComponent<Image>().raycastTarget = true;
            }
        }
    }
    public LineObj _NowLine;

    private void Awake()
    {
        _ = this;
    }

    void Start()
    {
    }

    void Update()
    {
        if (NowLine != null)
        {
            Vector3 NowV3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(StartV3, NowV3) > 0.5f)
            {
                StartV3 = NowV3;
                NowLine.AddNewPots(StartV3);
            }
        }
    }

    public LineObj CreatLine(Vector2 from, Vector2 to)
    {
        LineObj r = Instantiate(LineObjPre, transform);
        r.transform.position = from;
        r.lineRenderer.positionCount = 2;
        r.lineRenderer.SetPosition(1, to);
        return r;
    }

    public List<LineObj> GetAllLine()
    {
        List<LineObj> r = new List<LineObj>();
        MainLine.GetAllLine(r);

        return r;
    }
}
