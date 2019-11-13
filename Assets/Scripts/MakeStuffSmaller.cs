using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStuffSmaller : MonoBehaviour
{
    [SerializeField]
    private float scaleModifier;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Transform point;

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(point.position, target.position)*scaleModifier;
        
        
        target.localScale = (Vector3.one * dist);
    }
}
