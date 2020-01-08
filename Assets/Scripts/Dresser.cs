using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dresser : Interactable
{
    public override void Interact()
    {
        FuzzyPlayerVision.minStressValue -= 25;
        FuzzyPlayerVision.maxStressValue -= 20;
        interacted = true;
    }
}
