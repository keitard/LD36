using UnityEngine;
using System.Collections;

public class TombRaiderScript : MonoBehaviour
{
    public Transform target;
    Transform myTransform;
    Rigidbody myRigidbody;


    public float speed = 3f;

    void Awake()
    {
        myTransform = transform;
        myRigidbody = GetComponent<Rigidbody>();
        target = GameObject.Find("GoldenMonkey").transform;
    }

    void Update()
    {
        if(GameManager.Instance.IsGameStarted)
        {
            myTransform.LookAt(target.position);
            myRigidbody.velocity = myTransform.forward * speed;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        myTransform.position = Vector3.zero;
        myTransform.eulerAngles = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GoldenMonkey")
        {
            GameManager.Instance.IsGameOver = true;
        }
    }
}
