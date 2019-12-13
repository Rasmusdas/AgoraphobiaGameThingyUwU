using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Interactable
{
    public GameObject phoneScreen;
    public override void Interact()
    {
        phoneScreen.SetActive(true);
    }
}
