using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject_Base : MonoBehaviour
{
	public virtual void Initialize(int iID, Vector2 iPosition)
	{
		ID = iID;
		RectTransform.anchoredPosition = iPosition;
	}
	
	public RectTransform RectTransform;
	public int ID;
	public Animation Animation;
}
