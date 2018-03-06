using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlMovement : MonoBehaviour
{
    public Transform lvlTransform;
    public Vector3 lvlMovment;
    public float lvlSpeed;

	// Use this for initialization
	void Start ()
    {
        lvlMovment = lvlTransform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        lvlMovment.x = lvlMovment.x + lvlSpeed;
        lvlTransform.position = lvlMovment;
	}
}
