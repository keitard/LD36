using UnityEngine;
using System.Collections;

public class TombRaiderSpawner : MonoBehaviour
{
    public ObjectPooler objectPooler;
    public Transform[] spawnerTransform;

    public float timing = 0;

    void Update()
    {
        timing += Time.deltaTime;
        if(timing >= 3f)
        {
            GameObject tombRaider = objectPooler.GetPooledObject();
            tombRaider.transform.position = spawnerTransform[Random.Range(0, spawnerTransform.Length)].position;
            tombRaider.SetActive(true);
            timing = 0;
        }
    }

}
