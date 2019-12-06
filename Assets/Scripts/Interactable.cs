using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Transform player;
    public Material glow;
    public Material regular;

    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        regular = rend.material;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position,transform.position) < 3)
        {
            rend.material = glow;
        }
        else
        {
            rend.material = regular;
        }
    }
}
