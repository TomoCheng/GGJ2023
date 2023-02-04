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

	public ColorChart GetColorChart()
	{
		return colorChartList[UnityEngine.Random.Range(0, colorChartList.Count - 1)];
	}

	[SerializeField] private List<ColorChart> colorChartList;
}
