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

    void Update()
    {
        if (!GameManager.Instance.IsGameStarted)
            return;

        Vector3 desiredPosition = target.position + offset;
        myTransform.DOMove(desiredPosition, 0.5f).SetEase(Ease.Linear);

        myTransform.DOLookAt(target.position, 0.25f, AxisConstraint.None);
    }
}
