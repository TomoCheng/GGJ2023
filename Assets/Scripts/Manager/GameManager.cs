using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : Manager_Base
{
	public enum GameState
	{
		TITLE,
		GAME,
		RESULT,
	}
	private void Awake()
	{
		Initialize();
	}
	public override void Initialize()
	{
		SpawnManager.Initialize();

		base.Initialize();
	}
	private void PlayClickSound()
	{
		var aAudioObject = Instantiate(AudioObject);
		aAudioObject.SetClip(ClickSFX);
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.LogWarning("Press Space");
			PlayClickSound();
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			Debug.LogWarning("Press S");
			PlayClickSound();
			System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
			ScreenCapture.CaptureScreenshot(Application.dataPath + "/ScreenShot_" + DateTime.Now.ToString("yyMMdd") + "_" + rnd.GetHashCode() + ".png");
		}
	}
	public SpawnManager SpawnManager;
	public AudioObject AudioObject;
	public AudioClip   ClickSFX;
}
