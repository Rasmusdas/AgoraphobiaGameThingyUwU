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
        rend.material = glow;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if(dist < 5)
        {
            rend.material = glow;
            if(dist < 2)
            {
                dist = 2;
            }
            rend.material.SetFloat("_Glow_Amount", Mathf.Exp(dist));
        }
        else
        {
            rend.material = regular;
        }
    }
}
