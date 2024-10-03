using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Ville Kaikkonen
A simple script that is run when the player character reaches their goal
*/
public class PuzzleGoal : MonoBehaviour
{
    [SerializeField] string nextLevelName;
    [SerializeField] AudioClip victoryFanfare;
    GameManager gm;

    void LoadNextScene()
    {
        Debug.Log("Loading scene " + nextLevelName);
        if (gm == null) gm = FindObjectOfType<GameManager>();
        gm.LoadScene(nextLevelName);
    }

    IEnumerator EndWait()
    {
        yield return new WaitForSeconds(victoryFanfare.length);
        LoadNextScene();
    }

    // Called when a collider enters this object's trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Puzzle cleared.");
            collider.GetComponent<PuzzleCharacter>().SetControlsActivity(false);
            if (victoryFanfare != null)
            {
                if (gm == null) gm = FindObjectOfType<GameManager>();
                gm.PauseMusic();
                gm.PlaySound(victoryFanfare);
                StartCoroutine("EndWait");
            }
            else 
            {
                LoadNextScene();
            }
        }
    }
}
