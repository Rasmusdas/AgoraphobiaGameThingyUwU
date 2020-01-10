using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject canvas;
    bool active;
    public List<GameObject> storyItems;

    // Start is called before the first frame update
    void Start()
    {
        canvas = transform.GetChild(0).gameObject;
        active = canvas.activeInHierarchy;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    void TogglePauseGame()
    {
        bool storyItemActive = false;
        foreach (GameObject g in storyItems)
        {
            if (g.activeSelf)
            {
                storyItemActive = true;
            }
        }
        if (!storyItemActive)
        {
            active = !active;
            canvas.SetActive(active);
            if (active)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        TogglePauseGame();
    }
}
