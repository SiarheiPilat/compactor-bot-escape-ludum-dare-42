using UnityEngine;

public class DemoWall : MonoBehaviour {

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.layer == 10)
        {
            Manager.VelocityIncreasing = false;
            Manager.CanWall = false;
        }
    }

}
