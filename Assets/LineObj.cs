using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineObj : MonoBehaviour
{
    public LineRenderer lineRenderer;

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

    public void AddNewPots(Vector3 Pot)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, Pot);
        //是否產生分枝
        if (Random.Range(0, 11) == 0)
        {
            //<分支末端座標>
            //<產生新的分支物件>
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
}
