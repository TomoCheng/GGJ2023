using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager_Base
{
	public enum GameState
	{
		TITLE,
		GAME,
		RESULT,
	}
	private enum Direction
	{
		TOP,
		BOTTOM,
		LEFT,
		RIGHT,
	}
	public static GameManager GetInstance()
	{
		return FindObjectOfType<GameManager>();
	}
	private void Awake()
	{
		Initialize();
	}
	public override void Initialize()
	{
		SpawnManager.Initialize();
		DirectionPositionMap.Add(Direction.TOP   , new Vector2(0, BackgroundSize * -1));
		DirectionPositionMap.Add(Direction.BOTTOM, new Vector2(0, BackgroundSize      ));
		DirectionPositionMap.Add(Direction.LEFT  , new Vector2(BackgroundSize     , 0));
		DirectionPositionMap.Add(Direction.RIGHT , new Vector2(BackgroundSize * -1, 0));
		Group_Background.anchoredPosition = DirectionPositionMap[Direction.TOP];
		CurrentGameState = GameState.TITLE;
		base.Initialize();
	}
	private async UniTask EnterGame()
	{
		CurrentGameState = GameState.GAME;
		var aStart  = Group_Background.anchoredPosition;
		var aTarget = new Vector2(0, 0);

		float aAlpha = 0;
		while (aAlpha < 1)
		{
			aAlpha += Time.deltaTime * 2;
			aAlpha = aAlpha > 1 ? 1 : aAlpha;
			Group_Background.anchoredPosition = Vector2.Lerp(aStart, aTarget, aAlpha);
			await UniTask.Yield();
		}
		var aColorChart = GameSetting.GetInstance().ColorChartSetting.GetColorChart();
		var aColor      = aColorChart.Color[UnityEngine.Random.Range(0, aColorChart.Color.Length)];
		Line_Manager.gameObject.SetActive(true);
		Line_Manager.MainLine.ChangeColor(aColor, aColor);
		Group_Color.SetActive(true);
		Group_Brush.SetActive(true);
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
			if (CurrentGameState == GameState.TITLE)
			{
				PlayClickSound();
				EnterGame().Forget();
			}
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			Debug.LogWarning("Press S");
			PlayClickSound();
			System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
			ScreenCapture.CaptureScreenshot(Application.dataPath + "/ScreenShot_" + DateTime.Now.ToString("yyMMdd") + "_" + rnd.GetHashCode() + ".png");
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene("GameFlow");
		}
	}
	public SpawnManager SpawnManager;
	public AudioObject AudioObject;
	public AudioClip   ClickSFX;
	public RectTransform Group_Background;
	public float BackgroundSize = 1024.0f;
	private Dictionary<Direction, Vector2> DirectionPositionMap = new Dictionary<Direction, Vector2>();
	public GameState CurrentGameState;
	public Line_Manager Line_Manager;
	public GameObject   Group_Color;
	public GameObject   Group_Brush;
}
