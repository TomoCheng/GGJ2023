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
    public Vector2 test;
    public Vector2 test2;
    private void Update()
    {
        Button.position = LastPot;
    }

    public void AddNewPots(Vector3 Pot)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, Pot);
        //能量減少
        Line_Manager._.Power--;
        //能量數否足夠
        if (Line_Manager._.Power > 0)
        {
            //是否產生分枝
            if (Random.Range(0, 11) == 0)
            {
                //分支末端座標
                float rot = Vector2.SignedAngle(Vector2.right, LastPot - LastPot2) + (Random.Range(0, 2) * 2 - 1) * Random.Range(20, 46);
                Vector2 NewPot = LastPot2 + new Vector3(Mathf.Cos(rot / 360 * 2 * Mathf.PI), Mathf.Sin(rot / 360 * 2 * Mathf.PI), 0);
                //<產生新的分支物件>
                Line_Manager._.CreatLine(LastPot2, NewPot);
                Des();
                Line_Manager._.NowLine = Line_Manager._.CreatLine(Pot, Pot);
            }
        }
        else
        {
            Line_Manager._.NowLine = null;
            Des();
        }
    }

    //抓到底下所有的線分支
    public void GetAllLine(List<LineObj> lineObjs)
    {
        foreach(var i in NewLines)
        {
            lineObjs.Add(this);
            i.GetAllLine(lineObjs);
        }
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
            Line_Manager._.Power = Random.Range(3, 21);
            Line_Manager._.NowLine = this;
        }
        else
        {
            Line_Manager._.NowLine = null;
        }
    }
}
