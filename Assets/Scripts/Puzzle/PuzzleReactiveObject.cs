using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Author: Ville Kaikkonen
A collider testing script
*/
public class PuzzleReactiveObject : MonoBehaviour
{
    // Called when a collider enters this object's trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PuzzleObject"))
        {
            Debug.Log(collider.gameObject.name);
        }
    }
}
