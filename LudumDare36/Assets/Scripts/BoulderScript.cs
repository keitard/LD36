using UnityEngine;
using System.Collections;

public class BoulderScript : MonoBehaviour
{
    Rigidbody myRigidbody;
    Transform myTransform;
    Vector3 originalPosition;
    Vector3 originalRotation;

    public float forceRate;

    public GameObject bloodParticle;

    public Transform dustParticle;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myTransform = transform;
        originalPosition = myTransform.position;
        originalRotation = myTransform.eulerAngles;

        PoolManager.Instance.CreatePool(bloodParticle, 100);
    }

    void Update()
    {
        dustParticle.position = new Vector3(myTransform.position.x, 3, myTransform.position.z);
        //dustParticle.GetComponent<ParticleSystem>().rot
    }

    void FixedUpdate()
    {
        if (!GameManager.Instance.IsGameStarted)
        {
            gameObject.SetActive(false);
            dustParticle.gameObject.SetActive(false);
            return;
        }
        else
        {
            dustParticle.gameObject.SetActive(true);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        myRigidbody.AddForce(new Vector3(horizontal, 0, vertical) * forceRate, ForceMode.Force);
    }

    void OnDisable()
    {
        myTransform.position = originalPosition;
        myTransform.eulerAngles = originalRotation;
        myRigidbody.Sleep();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "TombRaider")
        {
            PoolManager.Instance.ReuseObject(bloodParticle, other.transform.position, other.transform.rotation);
            other.gameObject.SetActive(false);
            GameManager.Instance.Score++;
        }
    }
}
