using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSquasherDemo : WallSquasher {

    protected override void Squash()
    {
        Destroy(Manager.VelocityDetector);
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        Manager.CanWall = true;
        Destroy(this);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == name1)
        {
            isCollidedWithObj1 = true;
            Manager.TouchesWall = true;
        }
        else if (collision.gameObject.name == name2)
        {
            isCollidedWithObj2 = true;
            Manager.TouchesWall = true;
        }

        if (isCollidedWithObj1 && isCollidedWithObj2)
        {
            if (collision.gameObject.GetComponent<WallMover>())
                collision.gameObject.GetComponent<WallMover>().Speed = 0.000000001f;
            Squash();
        }
    }
}
