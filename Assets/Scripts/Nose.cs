using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nose : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D iCollision)
	{
		var aColor = iCollision.GetComponent<Image>().color;
		LineObj.ChangeColor(Color.white, aColor);
		var an = GameObject.Find("Image_Ink_Value_Fadeout").GetComponent<Animator>();
		//an.speed = 0.1f;
		an.Play("Ink_Fadeout");
	}
	public LineObj LineObj;
}
