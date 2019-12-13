using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public Transform player;
    public Material glow;
    public Material regular;
    float lastDist;
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        regular = rend.material;
        rend.material = glow;
    }

    bool Interacted { get; set; }
    public virtual void Interact()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if(dist < 5)
        {
            if(rend.material != glow)
            {
                rend.material = glow;
            }
            if(dist < 2)
            {
                dist = 2;
            }
            if(lastDist > dist + 0.1f && lastDist < dist - 0.1f)
            {
                rend.material.SetFloat("_Glow_Amount", Mathf.Exp(dist));
            }
            lastDist = dist;
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
