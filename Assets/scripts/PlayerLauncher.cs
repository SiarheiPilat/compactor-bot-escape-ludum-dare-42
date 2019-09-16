using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLauncher : MonoBehaviour {

    public float LaunchForce;
    public Vector3 Direction;

    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * LaunchForce, ForceMode.Impulse);
    }

}
