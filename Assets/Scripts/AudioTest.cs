using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioSource testSouce;
    public float whait;
    public float whait2;
    public bool audio = false;

    public List<AudioClip> clips;

    // Start is called before the first frame update
    void Start()
    {
        testSouce = transform.GetComponent<AudioSource>();
        StartCoroutine(AudioCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            testSouce.Play();
        }
    }

    void FixedUpdate()
    {/*
        if (audio)
        {
            new WaitForSeconds(whait);
            testSouce.Play();
        }*/
    }

    IEnumerator AudioCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(whait);
            if (audio)
            {
                testSouce.clip = clips[Random.Range(0, clips.Count)];
                testSouce.Play();
                yield return new WaitWhile(() => testSouce.isPlaying);
            }
        }
    }
}
