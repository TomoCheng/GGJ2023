using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineObj : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform Button;
    public Vector3 LastPot => lineRenderer.GetPosition(lineRenderer.positionCount - 1);
    public Vector3 LastPot2 => lineRenderer.GetPosition(lineRenderer.positionCount - 2);

    //分支
    public List<LineObj> NewLines;

    void Start()
    {
        NewLines = new List<LineObj>();

        // 初始點為物件座標
        Vector3 v3 = transform.position + Vector3.zero;
        v3.z = 0;
        lineRenderer.SetPosition(0, v3);
    }

    private void Update()
    {
        Button.position = LastPot;
    }

    public void AddNewPots(Vector3 Pot)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, Pot);
        //能量數否足夠
        if (Line_Manager._.Power_Current > 0)
        {
            //是否產生分枝
            if (Random.Range(0, 11) == 0)
            {
                //分支末端座標
                float rot = Vector2.SignedAngle(Vector2.right, LastPot - LastPot2) + (Random.Range(0, 2) * 2 - 1) * Random.Range(20, 46);
                Vector2 NewPot = LastPot2 + new Vector3(Mathf.Cos(rot / 360 * 2 * Mathf.PI), Mathf.Sin(rot / 360 * 2 * Mathf.PI), 0);
                //<產生新的分支物件>
                NewLines.Add(Line_Manager._.CreatLine(LastPot2, NewPot, lineRenderer.endColor));
                Des();
                NewLines.Add(Line_Manager._.NowLine = Line_Manager._.CreatLine(Pot, Pot, lineRenderer.endColor));
            }
        }
        else
        {
            Line_Manager._.NowLine = null;
            Line_Manager._.UpSizeAll();
			//Des();
			OnOffManager(false);
		}
    }

    //抓到底下所有的線分支
    public void GetAllLine(ref List<LineObj> lineObjs)
    {
        lineObjs.Add(this);
        foreach (var i in NewLines)
        {
            if (i.NewLines.Count != 0)
            {
                i.GetAllLine(ref lineObjs);
            }
        }
    }

    public void UpSize()
    {
        float a = Mathf.Min(lineRenderer.widthCurve.keys[0].value + 0.06f, 0.35f);
        lineRenderer.widthCurve = AnimationCurve.Linear(0, a, 1, a - 0.1f);
    }

    // 自我封印變成不可能在生長的狀態
    public void Des()
    {
        Button.gameObject.SetActive(false);
	}

    public void OnOffManager(bool OnOff)
    {
		if (OnOff)
        {
            Line_Manager._.NowLine = this;
        }
        else
        {
            Line_Manager._.NowLine = null;
        }
		Line_Manager._.OnOffManager(OnOff);
	}


	public void ChangeColor(Color? iStart, Color? iEnd)
	{
		if (iStart.HasValue)
		{
			lineRenderer.startColor = iStart.Value;
			lineRenderer.material.SetColor("_StartColor", iStart.Value);
		}
		if (iEnd.HasValue)
		{
			lineRenderer.endColor = iEnd.Value;
			lineRenderer.material.SetColor("_EndColor", iEnd.Value);
		}
	}
}
