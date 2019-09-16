using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiJitter : MonoBehaviour {

    Rigidbody rbd;
    [Range(2.0f, 10.0f)]
    public float JitterThreshold;

	// Use this for initialization
	void Start () {
        rbd = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(rbd.velocity.magnitude);
        if (rbd.velocity.magnitude > JitterThreshold)
            rbd.isKinematic = true;
	}
}
