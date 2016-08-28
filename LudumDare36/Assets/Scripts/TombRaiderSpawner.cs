using UnityEngine;
using System.Collections;

public class TombRaiderSpawner : MonoBehaviour
{
    public GameObject[] tombRaiders;

    public Transform[] spawnerTransform;

    float spawnTime = 5f;
    float spawnSpeed = 1.5f;

    void Awake()
    {
        foreach(GameObject tombRaider in tombRaiders)
        {
            PoolManager.Instance.CreatePool(tombRaider, 30);
        }
    }

    void Update()
    {
        spawnTime -= Time.deltaTime * spawnSpeed;
        if(spawnTime <= 0f)
        {
            int spawner = Random.Range(0, spawnerTransform.Length);
            PoolManager.Instance.ReuseObject(tombRaiders[Random.Range(0, tombRaiders.Length)], spawnerTransform[spawner].position, spawnerTransform[spawner].rotation);
            spawnTime = 10f;
        }

        GameManager.Instance.TimeToIncrementSpawnSpeed += Time.deltaTime;
        if(GameManager.Instance.TimeToIncrementSpawnSpeed >= 10f)
        {
            spawnSpeed += Random.Range(0.5f, 1.5f);
            GameManager.Instance.TimeToIncrementSpawnSpeed = 0;
        }
    }

}
