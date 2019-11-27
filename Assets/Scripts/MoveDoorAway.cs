using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoorAway : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform door;

    [SerializeField]
    private float distance;
    void Update()
    {
        if (Vector3.Distance(player.position,door.position) < distance)
        {
            StartCoroutine(MovingDoorAway(5));
        }
    }

    IEnumerator MovingDoorAway(int distance)
    {
        if(distance <= 1000)
        {
            transform.localScale = new Vector3(1,1, transform.localScale.z)*(1+(2f/distance));
            yield return new WaitForSeconds(0f);
            StartCoroutine(MovingDoorAway(distance+8));
        }
    }
}
