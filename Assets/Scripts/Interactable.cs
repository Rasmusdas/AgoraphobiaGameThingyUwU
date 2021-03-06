﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected Transform player;
    public Material glow;
    protected Material regular;
    [SerializeField]
    protected AudioSource sound;
    float lastDist;
    Renderer rend;
    protected float glowFactor;
    public bool interacted;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rend = GetComponent<Renderer>();
        regular = rend.material;
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
