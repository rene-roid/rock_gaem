using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text textNoob;
    public string[] texts;
    public GameObject babyMode;

    // Start is called before the first frame update
    void Start()
    {
        textNoob.text = texts[Random.Range(0, texts.Length-1)];
    }

    // Update is called once per frame
    void Update()
    {
        if (textNoob.text == texts[4])
        {
            textNoob.color = Color.magenta;
            babyMode.SetActive(true);
        } else
        {
            textNoob.color = Color.red;
            babyMode.SetActive(false);
        }
    }

    public void playAgain()
    {
        PlayerHP.ded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BabyModeEnter()
    {
        PlayerHP.ded = false;
        SceneManager.LoadScene("BabyMode");
    }
}
