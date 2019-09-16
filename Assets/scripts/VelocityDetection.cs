using UnityEngine;

public class VelocityDetection : MonoBehaviour {
	
	void Update () {
        DetectPlayerVelocity();
    }

    private void DetectPlayerVelocity()
    {
        if (Manager.PlayerRigidbody.velocity.magnitude > 0.0f)
        {
            Manager.VelocityIncreasing = true;
        }
        else Manager.VelocityIncreasing = false;
    }
}
