using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenEndDoor : Interactable
{
    public bool open;
    public Vector3 closedRotation;
    public Vector3 openRotation;
    public Light endLight;
    public Vector3 savePlayerRotation;
  
    public override void Interact()
    {
        open = true;
        savePlayerRotation = player.eulerAngles;
        StartCoroutine(EndGame());
    }


    // Update is called once per frame
    public override void Update()
    {
        if (PlayerStress.maxStressValue <= 60)
        {
            transform.tag = "Interactable";
        }
        if (open)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(openRotation), 5 * Time.deltaTime);
            endLight.intensity += 0.5f;
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(closedRotation), 5 * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        if(open)
        {
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.transform.eulerAngles = savePlayerRotation;
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
