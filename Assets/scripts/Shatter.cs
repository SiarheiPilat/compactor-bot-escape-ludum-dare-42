using UnityEngine;

public class Shatter : WallSquasher
{

    public GameObject ShatteredVersion;

    protected override void Squash()
    {
        Instantiate(ShatteredVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
