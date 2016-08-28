using UnityEngine;
using System.Collections;

public class BoulderScript : MonoBehaviour
{
    Rigidbody myRigidbody;

    public float forceRate = 5f;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        myRigidbody.AddForce(new Vector3(horizontal, 0, vertical) * forceRate, ForceMode.Force);
    }

}
