using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerStress : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume ppv;
    private Grain g;
    private Vignette v;
    private ColorGrading cG;

    [SerializeField]
    private Transform playerCamera;
    private float stressFactor;

    public static float maxStressValue = 100f;
    public static float minStressValue = 25f;
    public static float deltaStress = 1f;

    private void Start()
    {
        ppv.profile.TryGetSettings(out g);
        ppv.profile.TryGetSettings(out cG);
        ppv.profile.TryGetSettings(out v);
    }
    private void Update()
    {
        bool rayHit = Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, 10f);
        if(rayHit)
        {
            if (hit.transform.tag == "OutsideDoor")
            {
                if (stressFactor < maxStressValue)
                {
                    stressFactor += deltaStress*1.5f;
                }
            }
        }
        if (stressFactor > minStressValue)
        {
            stressFactor -= deltaStress * 0.5f;
        }
        g.intensity.value = stressFactor / 100;
        v.intensity.value = stressFactor / 200;
        cG.saturation.value = -stressFactor;
        if(stressFactor < minStressValue)
        {
            stressFactor = minStressValue;
        }
    }
}
