using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowEffect : MonoBehaviour
{
    int r = 255;
    int g = 0;
    int b = 0;

    Renderer rend;

    [ColorUsageAttribute(true, true)]
    Color color = new Color();

    private void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(StartRainbow());
    }

    IEnumerator StartRainbow()
    {
        for (int i = 0; i <= 255; i += 10)
        {
            print("g++");
            yield return new WaitForSeconds(0.001f);
            g = i;
            rend.material.SetColor("_Color", new Color(r, g, b)/ 64);
        }
        for (int i = 255; i >= 0; i -= 10)
        {
            print("r--");
            yield return new WaitForSeconds(0.001f);
            r = i;
            rend.material.SetColor("_Color", new Color(r, g, b) / 64);
        }
        for (int i = 0; i <= 255; i += 10)
        {
            print("b++");
            yield return new WaitForSeconds(0.001f);
            b = i;
            rend.material.SetColor("_Color", new Color(r, g, b) / 64);
        }
        for (int i = 255; i >= 0; i -= 10)
        {
            print("g--");
            yield return new WaitForSeconds(0.001f);
            g = i;
            rend.material.SetColor("_Color", new Color(r, g, b) / 64);
        }
        for (int i = 0; i <= 255; i += 10)
        {
            print("r++");
            yield return new WaitForSeconds(0.001f);
            r = i;
            rend.material.SetColor("_Color", new Color(r, g, b) / 64);
        }
        for (int i = 255; i >= 0; i -= 10)
        {
            print("b--");
            yield return new WaitForSeconds(0.001f);
            b = i;
            rend.material.SetColor("_Color", new Color(r, g, b) / 64);
        }
        StartCoroutine(StartRainbow()); 
    }
}
