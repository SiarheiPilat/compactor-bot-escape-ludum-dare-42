using UnityEngine;

public class ddestroy : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
