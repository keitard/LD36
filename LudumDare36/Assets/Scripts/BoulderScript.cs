using UnityEngine;
using System.Collections;

public class BoulderScript : MonoBehaviour
{
    Rigidbody myRigidbody;

    public float forceRate;

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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "TombRaider")
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.Score++;
        }
    }
}
