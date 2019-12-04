using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    // Dictionary<string,AudioSource> audioSouces = new Dictionary<string, AudioSource>();
    public List<AudioSource> audioSouces;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
        }
    }

    public void PlaySoundEffect(string tag)
    {
        for (int i = 0; i < audioSouces.Count; i++)
        {
            if (audioSouces[i].CompareTag(tag))
            {
                audioSouces[i].Play();
            }
        }
    }
}
