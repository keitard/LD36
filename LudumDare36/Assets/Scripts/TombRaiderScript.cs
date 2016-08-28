using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TombRaiderScript : MonoBehaviour
{
    public Transform target;
    Transform myTransform;
    Rigidbody myRigidbody;


    public float speed = 5f;

    void Awake()
    {
        myTransform = transform;
        myRigidbody = GetComponent<Rigidbody>();
        target = GameObject.Find("GoldenMonkeyTreasure").transform;
    }

    void OnEnable()
    {
        myRigidbody.DOMove(new Vector3(target.position.x, 0.75f, target.position.z), speed).SetEase(Ease.Linear).SetAutoKill(false).SetSpeedBased();
        myTransform.DOLookAt(new Vector3(target.position.x, myTransform.position.y, target.position.z), Time.deltaTime);
    }
    
    void Update()
    {
        //myTransform.LookAt(new Vector3(target.position.x, myTransform.position.y, target.position.z));
    }

    void OnDisable()
    {
        myRigidbody.DOKill();
        myTransform.position = Vector3.zero;
        myTransform.eulerAngles = Vector3.zero;
    }
}
