using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : Interactable
{
    public ParticleSystem ps;
    public AudioSource turnOn;
    public AudioSource turnOff;
    public override void Interact()
    {
        FuzzyPlayerVision.minStressValue -= 10;
        FuzzyPlayerVision.maxStressValue -= 10;
        interacted = true;
        StartCoroutine(UseShower());
    }

    public IEnumerator UseShower()
    {
        ps.Play();
        turnOn.Play();
        yield return new WaitForSeconds(0.2f);
        sound.Play();
        yield return new WaitForSeconds(9f);
        turnOff.Play();
        sound.Stop();
        ps.Stop();
        
    }
}
