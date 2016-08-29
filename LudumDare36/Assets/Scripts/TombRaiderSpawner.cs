using UnityEngine;
using System.Collections;

public class TombRaiderSpawner : MonoBehaviour
{
    static TombRaiderSpawner instance;
    public static TombRaiderSpawner Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TombRaiderSpawner>();
            }
            return instance;
        }
    }

    public GameObject[] tombRaiders;

    public Transform[] spawnerTransform;

    public float spawnTime = 5f;
    public float spawnSpeed = 1f;

    void Awake()
    {
        foreach(GameObject tombRaider in tombRaiders)
        {
            PoolManager.Instance.CreatePool(tombRaider, 30);
        }
    }

    void Update()
    {
        if (!GameManager.Instance.IsGameStarted)
            return;

        spawnTime -= Time.deltaTime * spawnSpeed;
        if(spawnTime <= 0f)
        {
            int spawner = Random.Range(0, spawnerTransform.Length);
            PoolManager.Instance.ReuseObject(tombRaiders[Random.Range(0, tombRaiders.Length)], spawnerTransform[spawner].position, spawnerTransform[spawner].rotation);
            spawnTime = 15f;
        }

        GameManager.Instance.TimeToIncrementSpawnSpeed += Time.deltaTime;
        if(GameManager.Instance.TimeToIncrementSpawnSpeed >= 30f)
        {
            spawnSpeed += Random.Range(0.5f, 1.5f);
            GameManager.Instance.TimeToIncrementSpawnSpeed = 0;
        }
    }

}
