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

	[SerializeField] private List<ColorChart> colorChartList;
}
