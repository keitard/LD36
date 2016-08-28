using UnityEngine;
using System.Collections;

public class LookAtCenter : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(new Vector3(0, 0.75f, 0));
    }
}
