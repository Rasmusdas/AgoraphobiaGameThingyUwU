using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Interactable
{
    public GameObject phoneScreen;
    public override void Interact()
    {
        phoneScreen.SetActive(true);
        interacted = true;
        StartCoroutine(CloseScreen());
        PlayerStress.minStressValue += 10;
        PlayerStress.maxStressValue += 10;
    }

    private IEnumerator CloseScreen()
    {
        yield return new WaitForSeconds(10f);
        phoneScreen.SetActive(false);
    }

}
