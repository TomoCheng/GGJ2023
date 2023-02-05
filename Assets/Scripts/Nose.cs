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
	}
	public LineObj LineObj;
}
