using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerSoundTest : MonoBehaviour
{
    public AudioClip on;
    public AudioClip off;
    public AudioClip running;
    public AudioSource shower;
    public bool showerOn = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ToggleShower();
        }
    }

    void ToggleShower()
    {
        if (showerOn)
        {
            shower.clip = off;
            shower.Play();
            shower.loop = false;
        }
        else
        {
            shower.clip = on;
            shower.Play();
            shower.clip = running;
            shower.Play();
            shower.loop = true;
        }
        showerOn = !showerOn;
    }
}
