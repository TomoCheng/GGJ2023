using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
	public static GameSetting GetInstance()
	{
		return FindObjectOfType<GameSetting>();
	}
	private void Awake()
	{
		ColorChartSetting.Initialize();
	}
	public ColorChartSetting ColorChartSetting;
}
