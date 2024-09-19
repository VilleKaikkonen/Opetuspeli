using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Author: Ville Kaikkonen
Resets a level to avoid getting stuck in a puzzle
*/
public class PuzzleResetButton : MonoBehaviour
{
    // Loads the current scene, effectively restarting it
    public void ResetPuzzle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
