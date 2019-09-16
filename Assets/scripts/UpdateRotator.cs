using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRotator : MonoBehaviour {

    public float Speed;

	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * Time.deltaTime * Speed, Space.World);
    }
}
