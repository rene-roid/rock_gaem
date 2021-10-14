using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Opening scene
        SceneManager.LoadScene("Testing");
    }

    public void QuitGame()
    {
        // Quitting game
        Debug.Log("Quit");
        Application.Quit();
    }
}
