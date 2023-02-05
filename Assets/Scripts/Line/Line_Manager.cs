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
	
	public float Power_Max;
	public float Power_Current;

    public float Max_X = 5;
    public float Min_X = -5;
    public float Max_Y = 6;
    public float Min_Y = -4;

    private void Awake()
    {
        _ = this;
		Power_Max = Random.Range(7, 15);
		Power_Current = Power_Max;
	}

    void Start()
    {
    }

	public float InkCostSpeed = 100.0f;
    void Update()
    {
        //print(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (NowLine != null)
        {
            Vector3 NowV3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            NowV3 = new Vector3(Mathf.Clamp(NowV3.x, Min_X, Max_X), Mathf.Clamp(NowV3.y, Min_Y, Max_Y));
            if (Vector3.Distance(StartV3, NowV3) > 0.5f)
            {
                StartV3 = NowV3;
				Power_Current -= Time.deltaTime * InkCostSpeed;
				NowLine.AddNewPots(StartV3);
            }

        }
		var aAlpha = Power_Current / Power_Max;
		Image_Ink_Value.fillAmount = aAlpha;
		Animator_Brush.speed = 1.2f - aAlpha;
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
		r.ChangeColor(iStarColor, iStarColor);
		return r;
    }

    public List<LineObj> GetAllLine()
    {
        List<LineObj> r = new List<LineObj>();
        MainLine.GetAllLine(ref r);

        return r;
    }

	public AudioSource AudioSource;
	public void OnOffManager(bool OnOff)
	{
		if (OnOff)
		{
			AudioSource.Play();
			Image_Ink_Value.material.SetColor("_StartColor", NowLine.lineRenderer.startColor);
			Image_Ink_Value.material.SetColor("_EndColor"  , NowLine.lineRenderer.endColor);
		}
		else
		{
			AudioSource.Pause();
			Power_Max = Random.Range(3, 21);
			Power_Current = Power_Max;
		}
	}

	public Image Image_Ink_Value;
	public Animator Animator_Brush;
}
