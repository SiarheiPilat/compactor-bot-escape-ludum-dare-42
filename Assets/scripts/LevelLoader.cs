using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Class for loading levels using UI.
/// </summary>

public class LevelLoader : MonoBehaviour {

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
