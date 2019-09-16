using UnityEngine;

/// <summary>
/// Controls whether the player is squashed by two walls. Should be sitting on the player.
/// Taken from here: https://gamedev.stackexchange.com/questions/109176/how-can-i-detect-if-a-gameobject-has-collided-with-two-other-specific-objects-at
/// </summary>

public class WallSquasher : MonoBehaviour {


    [SerializeField]
    protected string name1, name2;

    protected bool isCollidedWithObj1 = false;
    protected bool isCollidedWithObj2 = false;

    private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController controller;
    private AudioSource audioSource;

    [SerializeField]
    private GameObject screamText;
    private bool squashing;
    [SerializeField]
    private AudioClip deathScream, robotWalk;

    private bool deadYet;

    protected virtual void Start()
    {
        deadYet = false;
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
        squashing = false;
    }

    protected virtual void OnCollisionEnter(Collision collision)
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
            Squash();
    }

    protected virtual void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == name1)
        {
            isCollidedWithObj1 = false;
            Manager.TouchesWall = false;
        }
        else if (collision.gameObject.name == name2)
        {
            isCollidedWithObj2 = false;
            Manager.TouchesWall = false;
        }
    }

    protected virtual void Squash()
    {
        deadYet = true;
        PlaySquashingDeathSound();
        Destroy(Manager.VelocityDetector);
        Manager.PlayerRigidbody.useGravity = false;
        Manager.PlayerRigidbody.isKinematic = true;
        controller.enabled = false;
        Manager.CanWall = true;
        Time.timeScale = 0.25f;
        squashing = true;
        if (screamText)
            screamText.SetActive(true);
    }

    private void PlaySquashingDeathSound()
    {
        audioSource.PlayOneShot(deathScream);
    }

    private void Update()
    {
        if (Manager.WASDDetected && Manager.VelocityIncreasing)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else if (!deadYet) audioSource.Stop();

        if (squashing)
        {
            Camera.main.fieldOfView -= 0.1f;
        }
    }
}
