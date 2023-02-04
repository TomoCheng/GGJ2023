using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nose : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D iCollision)
	{
		LineObj.lineRenderer.endColor = iCollision.GetComponent<Image>().color;
	}
	public LineObj LineObj;
}
