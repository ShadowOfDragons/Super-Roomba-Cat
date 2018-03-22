using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleBackground : MonoBehaviour
{
    [Header("Background")]
    public GameObject[] lvlBackground;
    public Vector3 backgroundPos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Instantiate(lvlBackground[Random.Range(0, lvlBackground.GetLength(0))], backgroundPos, Quaternion.identity);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
