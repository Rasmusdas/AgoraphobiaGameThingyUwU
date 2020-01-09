using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interactable
{
    public bool open = false;
    public Vector3 closedRotation;
    public Vector3 openRotation;

    public override void Interact()
    {
        open = !open;
        sound.Play();
    }

    public override void Update()
    {
        if (open)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(openRotation), 5* Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(closedRotation), 5* Time.deltaTime);
        }
    }
}
