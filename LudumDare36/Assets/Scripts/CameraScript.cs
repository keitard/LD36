using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    Transform myTransform;
    Vector3 offset;

    void Start()
    {
        myTransform = transform;
        offset = myTransform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        myTransform.DOMove(desiredPosition, Time.deltaTime);
    }
}
