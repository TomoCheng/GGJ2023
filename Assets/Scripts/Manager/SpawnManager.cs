using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Manager_Base
{
	public override void Initialize()
	{

		base.Initialize();
	}
	public Nutrition SpawnNutrition(Vector2 iPosition)
	{
		var aNutrition = Instantiate(Nutrition, Background);
		NutritionList.Add(aNutrition);
		var aLast = NutritionList[NutritionList.Count - 1];
		aNutrition.Initialize(aLast.ID + 1, iPosition);
		return aNutrition;
	}

	//Test
	private void Update()
	{
		Tick += Time.deltaTime;
		if (Tick > SpawnPeriod)
		{
			SpawnNutrition(new Vector2(Random.Range(-450, 450), Random.Range(-450, 450)));
			Tick = 0;
		}
	}
	private float Tick;
	public float SpawnPeriod;
	//Test

	public Nutrition Nutrition;
	public Transform Background;

	private List<Nutrition> NutritionList = new List<Nutrition>();
}
