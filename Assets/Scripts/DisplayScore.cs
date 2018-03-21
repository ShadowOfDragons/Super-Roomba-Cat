using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text currentScore;
    public Text lastHighscore;

    private int score = 0;
    private int highscore = 0;

    // Use this for initialization
    void Start ()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        score = PlayerPrefs.GetInt("Score");
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentScore.text = score.ToString();
        lastHighscore.text = highscore.ToString();
	}
}
