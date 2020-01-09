using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dresser : Interactable
{
    public override void Interact()
    {
        PlayerStress.minStressValue -= 25;
        PlayerStress.maxStressValue -= 20;
        interacted = true;
    }
}
