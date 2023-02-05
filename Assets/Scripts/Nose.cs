using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nose : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D iCollision)
	{
		if (iCollision.name.Contains("Nutrition"))
		{
			var aColor = iCollision.GetComponent<Image>().color;
			LineObj.ChangeColor(Color.white, aColor);
			var aNutrition = iCollision.GetComponent<Nutrition>();
			aNutrition.CollisionLineObj = LineObj;
			aNutrition.DestroyNutrition(true);
		}
	}
	public LineObj LineObj;
}
