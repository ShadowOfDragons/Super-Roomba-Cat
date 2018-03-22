using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LogoScreen : MonoBehaviour
{

    public VideoPlayer video;

	// Use this for initialization
	void Start ()
    {
        video.Play();
        video.loopPointReached += CheckOver;
	}
	
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(1);
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}
