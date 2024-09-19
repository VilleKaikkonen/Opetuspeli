using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Ville Kaikkonen
Detects when a puzzle object enters the object and then "opens" a door
*/
public class Puzzle1ReactiveObject : MonoBehaviour
{
    [SerializeField] GameObject door;

    // Called when a collider enters this object's trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PuzzleObject"))
        {
            door.SetActive(false);
            collider.GetComponent<Transform>().localPosition 
            = GetComponent<Transform>().localPosition;
            collider.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            this.gameObject.SetActive(false);
        }
    }

    /* void OnTriggerExit2D(Collider2D collider)
    {
        door.SetActive(true);
    } 
    */
}
