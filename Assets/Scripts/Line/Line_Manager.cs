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
            _NowLine = value;
            if (_NowLine != null)
            {
                StartV3 = NowLine.lineRenderer.GetPosition(NowLine.lineRenderer.positionCount - 1);
            }
        }
    }
    public LineObj _NowLine;

    public int Power = 10;

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
        if (Input.GetKeyDown(KeyCode.A))
        {
            var allLine = GetAllLine();
            foreach (var i in allLine)
            {
                i.UpSize();
            }
        }


    }

    public void UpSizeAll()
    {
        var allLine = GetAllLine();
        foreach (var i in allLine)
        {
            i.UpSize();
        }
    }

    public LineObj CreatLine(Vector2 from, Vector2 to, Color iStarColor)
    {
        LineObj r = Instantiate(LineObjPre, transform);
        r.transform.position = from;
        r.lineRenderer.positionCount = 2;
        r.lineRenderer.SetPosition(1, to);
		r.lineRenderer.startColor = iStarColor;
		return r;
    }

    public List<LineObj> GetAllLine()
    {
        List<LineObj> r = new List<LineObj>();
        MainLine.GetAllLine(ref r);

        return r;
    }
}
