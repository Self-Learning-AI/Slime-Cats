using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    public string mainMenuScene = "Main Menu";
    public string gameScene = "Game Scene";

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }


        
    }

    public void Resume()
    {
        gameIsPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        gameIsPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0.1f;
    }

    public void Options()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
        StartCoroutine(CoQuitGame());
    }

    public IEnumerator CoQuitGame()
    {
        Debug.Log("Quitting Game...");
        yield return new WaitForSeconds(2.5f);
        Application.Quit();

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(gameScene);
    }
}
