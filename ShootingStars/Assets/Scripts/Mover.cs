using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mover : MonoBehaviour {

    public float speed;

	void Start () {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = transform.forward * speed;
	}
}
