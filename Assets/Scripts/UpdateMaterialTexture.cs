using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMaterialTexture : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
		Image.material.SetTexture("_Texture2D", Image.mainTexture);
	}
	public Image Image;
}
