using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEgg : MonoBehaviour
{
    public AudioSource AS;
    public int AnyButtonIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!AS.isPlaying)
            {
                AS.Play();
            }
        }
        else if (Input.anyKeyDown)
        {
            AnyButtonIndex = (AnyButtonIndex + 1) % 44;
            if (AnyButtonIndex == 0)
            {
                if (!AS.isPlaying)
                {
                    AS.Play();
                }
            }
        }
    }
}
