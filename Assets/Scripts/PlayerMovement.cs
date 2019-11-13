using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal")*movementSpeed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * movementSpeed*Time.deltaTime;

        transform.Translate(x,0,y);
    }
}
