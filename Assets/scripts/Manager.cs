using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for multiple static controls and scene management.
/// </summary>

public class Manager : MonoBehaviour {

    public static GameObject Player;
    public static Rigidbody PlayerRigidbody;
    public static VelocityDetection VelocityDetector;
    public static UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController RbdController;

    /// <summary>
    /// Controls whether the walls are closing.
    /// </summary>
    public static bool CanWall;

    public static bool WASDDetected;
    public static bool VelocityIncreasing;
    public static bool TouchesWall;

	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerRigidbody = Player.GetComponent<Rigidbody>();
        VelocityDetector = Player.GetComponent<VelocityDetection>();
        RbdController = Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
    }
	
    public static void RestartLevel()
    {
        Time.timeScale = 1.0f;
        Camera.main.fieldOfView = 60.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        DecideWhetherToMoveWalls();
    }

    /// <summary>
    /// This is horrible, but it seems to work.
    /// </summary>
    private static void DecideWhetherToMoveWalls()
    {
        if (VelocityIncreasing)
        {
            if (TouchesWall)
            {
                if (WASDDetected)
                    CanWall = true;
                else CanWall = false;
            }
            else CanWall = true;
        }
        else CanWall = false;
    }
}
