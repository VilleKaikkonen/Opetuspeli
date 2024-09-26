using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Ville Kaikkonen
Trigger for the first puzzle on second puzzle scene
*/
public class Puzzle2BooleanTrigger : PuzzleBaseReactiveObject
{
    [SerializeField] GameObject trueBlock;
    [SerializeField] GameObject falseBlock;
    [SerializeField] GameObject trueDoor;
    [SerializeField] GameObject falseDoor;

    // Called when a collider enters this object's trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PuzzleObject"))
        {
            if (collider.gameObject == trueBlock) 
            { 
                trueDoor.SetActive(false);
            }
            if (collider.gameObject == falseBlock) 
            { 
                falseDoor.SetActive(false); 
            }
            LockInObject(collider.gameObject);
        }
    }
}
