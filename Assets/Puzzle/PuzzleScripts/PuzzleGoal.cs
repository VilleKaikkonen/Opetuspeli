using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Ville Kaikkonen
A simple script that is run when the player character reaches their goal
*/
public class PuzzleGoal : MonoBehaviour
{
    // Called when a collider enters this object's trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Puzzle cleared.");
            collider.GetComponent<PuzzleCharacter>().SetControlsActivity(false);
        }
    }
}
