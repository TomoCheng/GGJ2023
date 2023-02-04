using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorChartSetting", menuName = "ScriptableObjects/ColorChartSetting")]
public class ColorChartSetting : ScriptableObject
{
	[Serializable]
	public struct ColorChart
	{
		public Color[] SpecialColor;
		public Color[] Color;
	}
	public void Initialize()
	{
		RandomColorChartIndex = UnityEngine.Random.Range(0, colorChartList.Count);
	}
	public ColorChart GetColorChart()
	{
		return colorChartList[RandomColorChartIndex];
	}

	[SerializeField] private List<ColorChart> colorChartList;
	private int RandomColorChartIndex;
}
