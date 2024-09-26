using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
Author: Ville Kaikkonen
Detects when a puzzle object enters the object and then "opens" a door
*/
public class Puzzle1ReactiveObject : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] TMP_Text scriptText;

    // Called when a collider enters this object's trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PuzzleObject"))
        {
            door.SetActive(false);
            collider.GetComponent<Transform>().localPosition 
            = GetComponent<Transform>().localPosition;
            collider.GetComponent<Rigidbody2D>().bodyType 
            = RigidbodyType2D.Kinematic;
            if (scriptText != null)
            {
                Color32 newColor = new Color32(255, 0, 13, 255);
                scriptText.color = newColor;
                collider.GetComponentInChildren<TMP_Text>().color = newColor;
            }
            this.gameObject.SetActive(false);
        }
    }

    /* void OnTriggerExit2D(Collider2D collider)
    {
        door.SetActive(true);
    } 
    */
}
