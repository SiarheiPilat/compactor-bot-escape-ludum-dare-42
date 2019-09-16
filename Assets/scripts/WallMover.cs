using UnityEngine;

/// <summary>
/// Should be sitting on the wall that can move. Moves wall in a specified direction.
/// </summary>

public class WallMover : MonoBehaviour {

    public AudioClip WallMove;
    private AudioSource audioSource;

    public enum Direction { up, down, left, right, back, forward };

    public Direction direction;

    private Vector3 directionVector;
    private bool moving;

    public float Speed;

    private Rigidbody wallRbd;

	void Start () {

        audioSource = GetComponent<AudioSource>();
        wallRbd = GetComponent<Rigidbody>();

        switch (direction)
        {
            case Direction.up:
                directionVector = Vector3.up;
                break;
            case Direction.down:
                directionVector = Vector3.down;
                break;
            case Direction.left:
                directionVector = Vector3.left;
                break;
            case Direction.right:
                directionVector = Vector3.right;
                break;
            case Direction.back:
                directionVector = Vector3.back;
                break;
            case Direction.forward:
                directionVector = Vector3.forward;
                break;
            default:
                break;
        }
    }
	
	void Update () {

        if (Manager.CanWall)
        {
            MoveWall();
        }
        else audioSource.Stop();


    }

    void MoveWall()
    {
        if(!audioSource.isPlaying)
            audioSource.Play();
        transform.Translate(directionVector * Time.deltaTime * Speed);
    }
}
