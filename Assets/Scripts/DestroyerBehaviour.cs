using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBehaviour : MonoBehaviour
{
    [Header("Background")]
    public GameObject[] lvlBackground;
    public Vector3 backgroundPos;

    [Header("Ground")]
    public GameObject[] lvlGround;
    public Vector3 groundPos;
    public float spawnMin;
    public float spawnMax;
    public float[] spawnPos;

    private void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        groundPos = new Vector3(60, spawnPos[Random.Range(0, spawnPos.GetLength(0))], 0);
        GameObject.Instantiate(lvlGround[Random.Range(0, lvlGround.GetLength(0))], groundPos, Quaternion.identity);
        Debug.Log("Spawned platform");

        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Environment")
        {
            GameObject.Instantiate(lvlBackground[Random.Range(0, lvlBackground.GetLength(0))], backgroundPos, Quaternion.identity);
        }        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
