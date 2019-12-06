using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    public Rigidbody rb;
    public AudioSource foodSteps;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        foodSteps = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 2 && !foodSteps.isPlaying)
        {
            foodSteps.Play();
        }
    }
}
