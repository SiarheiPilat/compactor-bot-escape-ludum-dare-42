using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Loading levels on entering doors.
/// </summary>

public class LevelLoadTrigger : MonoBehaviour {

    public string LevelName;

    private void OnTriggerEnter()
    {
        if(LevelName != string.Empty)
            SceneManager.LoadScene(LevelName);
    }

}
