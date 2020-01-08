using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : Interactable
{
    public override void Interact()
    {
        FuzzyPlayerVision.minStressValue -= 10;
        FuzzyPlayerVision.maxStressValue -= 10;
        interacted = true;
    }
}
