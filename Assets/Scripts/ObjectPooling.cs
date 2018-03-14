using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling current;
    public GameObject pooledObj;
    public int pooledAmount;
    public bool willGrow;

    List<GameObject> pooledObjs;

    private void Awake()
    {
        current = this;
    }

    // Use this for initialization
    void Start ()
    {
        pooledObjs = new List<GameObject>();
        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObj);
            obj.SetActive(false);
            pooledObjs.Add(obj);
        }
	}
	
	public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjs.Count; i++)
        {
            if(!pooledObjs[i].activeInHierarchy)
            {
                return pooledObjs[i];
            }
        }

        if(willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObj);
            pooledObjs.Add(obj);
            return obj;
        }

        return null;
    }
}
