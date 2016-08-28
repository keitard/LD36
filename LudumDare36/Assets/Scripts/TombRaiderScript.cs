using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TombRaiderScript : MonoBehaviour
{
    public Transform target;
    Transform myTransform;
    Rigidbody myRigidbody;


    public float speed = 2f;

    void Awake()
    {
        myTransform = transform;
        myRigidbody = GetComponent<Rigidbody>();
        target = GameObject.Find("GoldenMonkeyTreasure").transform;
    }

    void OnEnable()
    {
        myRigidbody.DOMove(new Vector3(target.position.x, myTransform.position.y, target.position.z), speed).SetEase(Ease.Linear).SetAutoKill(false).SetSpeedBased();

        myTransform.LookAt(target.position);
    }
    
    void OnDisable()
    {
        myRigidbody.DOKill();
        myTransform.position = Vector3.zero;
        myTransform.eulerAngles = Vector3.zero;
        print("Die!");

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {

            gameObject.SetActive(false);
        }
    }
}
