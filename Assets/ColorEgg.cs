using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEgg : MonoBehaviour
{
    public AudioSource AS;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!AS.isPlaying)
            {
                AS.Play();
            }
        }
    }
}
