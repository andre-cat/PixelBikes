using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio audio;

    void Awake()
    {
        if (audio == null)
        {
            Audio.audio = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void pausar(){
        
    }
}
