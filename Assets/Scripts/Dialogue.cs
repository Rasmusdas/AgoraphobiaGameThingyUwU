using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public List<TextMessageConversation> conversations = new List<TextMessageConversation>();
    public List<GameObject> textBoxes = new List<GameObject>();
    public GameObject textBoxBase;
    public Transform textParent;
    public Transform textStart;

    public AudioSource testSouce;
    public List<AudioClip> clips;

    private bool ready;
    private float timePerChar = 0.1f;
    private bool clear;

    private void Start()
    {
        GameObject textBox = Instantiate(textBoxBase,textStart.position,textBoxBase.transform.rotation,textParent);
        foreach (GameObject g in textBoxes)
        {
            g.transform.Translate(0, 100, 0);
        }
        textBoxes.Add(textBox);
        StartCoroutine(WriteLetter("owo what's this uwu", textBox));
    }

    public IEnumerator WriteLetter(string s, GameObject textBox)
    {
        Text text = textBox.transform.GetChild(0).GetComponent<Text>();
        ready = false;
        int i = 0;
        while (i < s.Length && !clear)
        {
            yield return new WaitForSeconds(timePerChar);
            text.text += s[i];
            testSouce.clip = clips[Random.Range(0, clips.Count)];
            testSouce.Play();
            i++;
        }
        text.text += "\n";
        if (clear)
        {
            text.text = "";
            clear = false;
        }
        yield return new WaitForSeconds(timePerChar * 10);
        ready = true;
    }
}

[System.Serializable]
public class TextMessageConversation
{
    public List<string> messages;
}