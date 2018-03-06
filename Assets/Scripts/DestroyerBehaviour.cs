using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBehaviour : MonoBehaviour
{
    public GameObject[] lvlPrefab;
    public Vector3 prefabCoord = new Vector3 (0, 0, 0);

    private void OnTriggerEnter2D(Collider2D other)
    {
        prefabCoord = new Vector3(60, 0, 0);
        GameObject.Instantiate(lvlPrefab[Random.Range(0, lvlPrefab.GetLength(0))], prefabCoord, Quaternion.identity);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
