using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletecatrige : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5f);
	}

    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
