using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : MonoBehaviour
{
    void Update()
    {
		Tick += Time.deltaTime;
		if (Tick >= 1)
		{
			Destroy(this.gameObject);
		}
	}
	float Tick;
}
