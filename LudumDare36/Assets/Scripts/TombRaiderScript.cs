using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TombRaiderScript : MonoBehaviour
{
    public Transform target;
    Transform myTransform;

    void Start()
    {
        myTransform = transform;
    }

    void Update()
    {
        myTransform.DOMove(new Vector3(target.position.x, transform.position.y, target.position.z), Time.deltaTime).SetEase(Ease.Linear);
    }

}
