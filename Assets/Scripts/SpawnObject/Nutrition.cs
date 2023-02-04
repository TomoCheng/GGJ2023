using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nutrition : SpawnObject_Base
{
	public override void Initialize(int iID, Vector2 iPosition)
	{
		var aAudioObject     = Instantiate(AudioObject);
		aAudioObject.SetClip(SpawnSFX[Random.Range(0, SpawnSFX.Length)]);
		var aColorChart      = GameSetting.GetInstance().ColorChartSetting.GetColorChart();
		Image.color          = aColorChart.Color[Random.Range(0, aColorChart.Color.Length)];
		LifeTime_Current     = LifeTime_Max;

		float aRandomScale   = Random.Range(1.0f, MaxRandomScale);
		transform.localScale = new Vector3(aRandomScale, aRandomScale, aRandomScale);

		Animator.speed       = 0.2f;
		base.Initialize(iID, iPosition);
	}
	public void SetSpeed()
	{
		Animator.speed = 0.4f - 0.3f * (LifeTime_Current / LifeTime_Max);
	}
	private void DestroyNutrition(bool iIsEat)
	{
		if (IsDestroy) { return; }
		Destroy(this.gameObject);
		var aAudioObject = Instantiate(AudioObject);
		aAudioObject.SetClip(iIsEat ? EatSFX : DestroySFX);
		IsDestroy = true;
	}
	private void Update()
	{
		if (!IsInitialize || IsDestroy) { return; }

		var aAnimatorinfo = Animator.GetCurrentAnimatorClipInfo(0);
		Current_animation = aAnimatorinfo[0].clip.name;
		if (Current_animation == "Nutrition_Loop")
		{
			LifeTime_Current -= Time.deltaTime;
			SetSpeed();
			if (LifeTime_Current <= 0)
			{
				DestroyNutrition(false);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D iCollision)
	{
		Debug.LogWarning(iCollision.name);
		if (iCollision.gameObject.name.Contains("Button"))
		{
			DestroyNutrition(true);
		}
	}



	public Image       Image;
	public AudioObject AudioObject;

	public  float  LifeTime_Max;
	private float  LifeTime_Current;
	private string Current_animation;
	private bool   IsDestroy;

	public AudioClip[] SpawnSFX;
	public AudioClip   DestroySFX;
	public AudioClip   EatSFX;

	public float MaxRandomScale = 1.5f;
}
