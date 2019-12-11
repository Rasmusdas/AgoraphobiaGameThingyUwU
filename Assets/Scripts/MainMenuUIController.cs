using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField]
    private string firstScene;

    public void StartGame()
    {
        SceneManager.LoadScene(firstScene);
    }

}
