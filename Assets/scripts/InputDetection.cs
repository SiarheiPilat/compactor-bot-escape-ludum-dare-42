using UnityEngine;

/// <summary>
/// Should be sitting on the player prefab. Detects whether any of the WASD keys is pressed.
/// </summary>

public class InputDetection : MonoBehaviour {
	
	void Update () {
        DetectInput();
	}

    void DetectInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space))
        {
            Manager.WASDDetected = true;
        }
        else
        {
            Manager.WASDDetected = false;
        }
        if (Input.GetKey(KeyCode.R))
        {
            Manager.RestartLevel();
        }
    }
}
