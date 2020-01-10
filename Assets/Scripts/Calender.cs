using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calender : Interactable
{
    public Material markedCalender;
    public override void Interact()
    {
        interacted = true;
        regular = markedCalender;
        GetComponent<Renderer>().material = markedCalender;
        PlayerStress.minStressValue -= 10;
        PlayerStress.maxStressValue -= 10;
    }
}
