using UnityEngine;

/// <summary>
/// Should be sitting on killing objects, e.g. lava
/// </summary>

public class DeathCollider : MonoBehaviour {

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
            Manager.RestartLevel();
    }

}
