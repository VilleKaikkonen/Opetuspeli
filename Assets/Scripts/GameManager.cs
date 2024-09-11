using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Authors: Ville Kaikkonen
Game Manager handles information across different scenes.
*/

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    // Awake is called when the script is loaded
    void Awake() {
        if (gameManager == null)
        {
            // Debug.Log("Preserving GameManager!");
            gameManager = this;
            DontDestroyOnLoad(this);
        } else if (gameManager != this)
        {
            // Debug.Log("Destroying GameManager!");
            Destroy(gameObject);
        }
    }

    // Loads a scene by its ID in scene hierarchy
    public void LoadScene(int sceneID) { SceneManager.LoadScene(sceneID); }

    // Loads a scene by its name
    public void LoadScene(string sceneName) { SceneManager.LoadScene(sceneName); }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
