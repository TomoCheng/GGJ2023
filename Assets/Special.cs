using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Special : MonoBehaviour
{
	public void SetColor(Color iColor)
	{
		Image_1.color = iColor;
	}
    void Update()
    {
		Tick += Time.deltaTime;
		if (Tick >= 1)
		{
			Destroy(this.gameObject);
		}
	}
	float Tick;
	public Image Image_1;
}
