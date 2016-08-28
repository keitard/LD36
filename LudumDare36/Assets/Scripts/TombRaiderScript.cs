using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TombRaiderScript : MonoBehaviour
{
    public Transform target;
    Transform myTransform;

    public float speed = 2f;

    void Start()
    {
        myTransform = transform;
        myTransform.DOMove(new Vector3(target.position.x, transform.position.y, target.position.z), speed).SetEase(Ease.Linear);
    }

    void Update()
    {

    }

}
