using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlaySurvival()
    {
        // Opening scene
        SceneManager.LoadScene("Testing");
    }

    public void Gamer()
    {
        // Opening scene
        SceneManager.LoadScene("Gamer");
    }

    public void PlayTutorial()
    {
        // Opening scene
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        // Quitting game
        Debug.Log("Quit");
        Application.Quit();
    }
}
