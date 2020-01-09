using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dresser : Interactable
{
    public AudioSource closeSound;
    public override void Interact()
    {
        PlayerStress.minStressValue -= 25;
        PlayerStress.maxStressValue -= 20;
        interacted = true;
        StartCoroutine(OpenClose());
        
    }
    IEnumerator OpenClose()
    {
        sound.Play();
        yield return new WaitForSeconds(2f);
        closeSound.Play();
    }
}
