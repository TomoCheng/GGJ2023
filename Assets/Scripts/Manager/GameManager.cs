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

	public SpawnManager SpawnManager;
}
