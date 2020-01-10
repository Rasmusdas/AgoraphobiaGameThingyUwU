using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryObject : Interactable
{
    public GameObject storyObject;

    public int stressChange;

    public override void Interact()
    {
        storyObject.SetActive(true);
        interacted = true;
        StartCoroutine(CloseScreen());
        PlayerStress.minStressValue += stressChange;
        PlayerStress.maxStressValue += stressChange;
    }

    private IEnumerator CloseScreen()
    {
        yield return new WaitForEndOfFrame();
        if (Input.GetKey(KeyCode.Escape))
        {
            storyObject.SetActive(false);
        }
        else
        {
            StartCoroutine(CloseScreen());
        }
    }

}
