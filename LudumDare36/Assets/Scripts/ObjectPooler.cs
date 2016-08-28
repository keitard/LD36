using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public GameObject[] pooledObject;
    public int pooledAmount = 10;
    public bool willGrow = true;
    int pooledObjectSize = 0;

    List<GameObject> pooledObjects;

    public string parentName;

    void Start()
    {
        Transform parent = new GameObject(parentName).transform;
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++, pooledObjectSize++)
        {
            if (pooledObjectSize >= pooledObject.Length)
                pooledObjectSize = 0;
            GameObject obj = Instantiate(pooledObject[pooledObjectSize]);
            obj.transform.SetParent(parent);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        pooledObjectSize = 0;
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        int pooledObjectPosition = Random.Range(0, pooledObject.Length);
        if (!pooledObjects[pooledObjectPosition].activeInHierarchy)
        {
            return pooledObjects[pooledObjectPosition];
        }

        if (willGrow)
        {
            for (int i = 0; i < pooledAmount; i++, pooledObjectSize++)
            {
                if (pooledObjectSize >= pooledObject.Length)
                    pooledObjectSize = 0;
                GameObject obj = Instantiate(pooledObject[pooledObjectSize]);
                pooledObjects.Add(obj);
                return obj;
            }
        }
        return null;
    }
}
