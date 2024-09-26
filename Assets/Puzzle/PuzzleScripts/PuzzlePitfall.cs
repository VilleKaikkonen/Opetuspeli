using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Ville Kaikkonen
Handles the event of an object "falling" into a pitfall object
*/
public class PuzzlePitfall : MonoBehaviour
{
    // Called when a collider enters this object's trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PuzzleCharacter>().SetControlsActivity(false);
            collider.GetComponent<SpriteRenderer>().color = Color.clear;
            Debug.Log("The player character has fallen into a pitfall.");
        } 
        else
        {
            Debug.Log("Object '" + collider.gameObject.name + "' has fallen into a pitfall!");
            collider.gameObject.SetActive(false);
        }
    }
}
