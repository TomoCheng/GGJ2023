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
		aNutrition.Initialize(aLast.ID, iPosition);
		return aNutrition;
	}

	//Test
	private void Update()
	{
		Tick += Time.deltaTime;
		if (Tick > 1.0f)
		{
			var aRandom = new System.Random();
			SpawnNutrition(new Vector2(aRandom.Next(0, 1920), aRandom.Next(0, 1080)));
			if (NutritionList.Count > 10)
			{
				var aNutrition = NutritionList[0];
				NutritionList.Remove(aNutrition);
				Destroy(aNutrition.gameObject);
			}
			Tick = 0;
		}
	}
	private float Tick;
	//Test

	public Nutrition Nutrition;
	public Transform Background;

	private List<Nutrition> NutritionList = new List<Nutrition>();
}
