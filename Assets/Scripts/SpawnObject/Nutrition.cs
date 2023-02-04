using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutrition : SpawnObject_Base
{
	public override void Initialize(int iID, Vector2 iPosition)
	{
		LifeTime_Current = LifeTime_Max;
		base.Initialize(iID, iPosition);
	}
	public void SetSpeed()
	{
		Animator.speed = 1 - (LifeTime_Current / LifeTime_Max);
	}
	private void Update()
	{
		if (!IsInitialize) { return; }

		LifeTime_Current -= Time.deltaTime;
		SetSpeed();
		if (LifeTime_Current <= 0)
		{
			Destroy(this.gameObject);
		}
	}

	public  float LifeTime_Max;
	private float LifeTime_Current;
}
