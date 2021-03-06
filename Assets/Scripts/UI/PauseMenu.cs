using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Calling variables
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI, controlMenuUI, settingsMenuUI;

    // Update is called once per frame
    void Update()
    {
        // Activating/Deactivating pause menu
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 3")) && !PlayerHP.ded)
        {
            if (gameIsPaused)
            {
                resume();
            } else
            {
                pause(); 
            }
        }
    }

    public void resume()
    {
        // Removing the pause menu/mode and setting timescale to 1
        setActiveMenus(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void pause()
    {
        // Pausing the game with timescale 0 and activating the pause menu & var
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void meainMenu()
    {
        // Resuming the timescale when going to the main menu
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void quitGame()
    {
        // Quitting the game
        Application.Quit();
    }

    private void setActiveMenus(bool isActive)
    {
        pauseMenuUI.SetActive(isActive);
        settingsMenuUI.SetActive(isActive);
        controlMenuUI.SetActive(isActive);
    }
}
