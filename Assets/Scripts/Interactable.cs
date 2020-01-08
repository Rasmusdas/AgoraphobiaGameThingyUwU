using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private Transform player;
    public Material glow;
    private Material regular;
    public AudioSource sound;
    float lastDist;
    Renderer rend;
    protected float glowFactor;
    protected bool interacted;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rend = GetComponent<Renderer>();
        regular = rend.material;
        glow.SetFloat("_Glow_Amount", 10);
    }

    public abstract void Interact();

    public virtual void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist < 5 && !interacted)
        {
            if(rend.material != glow)
            {
                rend.material = glow;
            }
        }
        else
        {
            if(rend.material != regular)
            {
                rend.material = regular;
            }
        }
    }
}
