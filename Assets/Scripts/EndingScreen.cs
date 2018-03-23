using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingScreen : MonoBehaviour
{
    public Text currentScore;
    public Text lastHighscore;

    private int score = 0;
    private int highscore = 0;

    public AudioSource sfx;
    public AudioClip crash;

    // Use this for initialization
    void Start()
    {
        sfx.PlayOneShot(crash);
        highscore = PlayerPrefs.GetInt("Highscore");
        score = PlayerPrefs.GetInt("Score");

        currentScore.text = score.ToString();
        lastHighscore.text = highscore.ToString();
    }

    public void PlayAgain()
    {
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }

        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }

        SceneManager.LoadScene(1);
    }

}
