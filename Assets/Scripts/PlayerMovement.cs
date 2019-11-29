using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float mouseSensitivity;

    [SerializeField]
    private Transform playerCamera;

    
    private bool pickedUp;

    [SerializeField]
    private Material shineShader;
    private Transform pickedUpItem;
    private Transform pickupHand;
    private Rigidbody rb;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Player Movement
        float x = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        Vector3 movementVector = transform.forward * y + transform.right*x;
        rb.velocity = new Vector3(movementVector.x,rb.velocity.y,movementVector.z);

        // Player Picking up object
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(!pickedUp)
            {
                bool rayHit = Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, 10f);
                if(rayHit)
                {
                    if (hit.transform.gameObject.tag == "Interactable")
                    {
                        Physics.IgnoreCollision(hit.collider, GetComponent<Collider>(), true);
                        pickedUpItem = hit.transform;
                        pickedUp = true;
                    }
                    Material pickupShader = pickedUpItem.GetComponent<Renderer>().material;
                    Texture _ = Utils.DeepClone<Texture>(pickupShader.mainTexture);
                    pickupShader.shader = shineShader.shader;
                    pickupShader.SetTexture("_Texture", _);
                }
                else
                {
                    pickupHand.gameObject.SetActive(false);
                }
            }
            else
            {
                Physics.IgnoreCollision(pickedUpItem.GetComponent<Collider>(), GetComponent<Collider>(), false);
                pickedUpItem = null;
                pickedUp = false;
            }
        }

        // Picked up object
        if(pickedUp)
        {
            if(pickedUpItem.GetComponent<Rigidbody>())
            {
                pickedUpItem.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if(Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, playerCamera.forward.magnitude*2,LayerMask.GetMask("Default")))
            {
                pickedUpItem.position = hit.point;
            }
            else
            {
                pickedUpItem.position = playerCamera.position + (playerCamera.forward * 2);
            }
            pickedUpItem.LookAt(playerCamera);
        }


        // Camera Rotation
        float mouseY = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseX = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.Rotate(0,mouseY,0);
        playerCamera.localEulerAngles = playerCamera.localEulerAngles + new Vector3(-mouseX,0,0);
        if(playerCamera.eulerAngles.z > 100) 
        {
            playerCamera.eulerAngles = new Vector3(playerCamera.eulerAngles.x, playerCamera.eulerAngles.y - 180, 0); // Prevents the camera from going crazy if you move the camera too far up
        }
        
    }
}
