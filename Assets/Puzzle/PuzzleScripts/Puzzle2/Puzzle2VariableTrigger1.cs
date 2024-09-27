using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Ville Kaikkonen
Trigger for the second puzzle on the second puzzle scene
*/
public class Puzzle2VariableTrigger1 : PuzzleBaseReactiveObject
{
    // [SerializeField] GameObject stringBlock;
    [SerializeField] GameObject intBlock;
    [SerializeField] GameObject stringBlock;
    [SerializeField] GameObject pitfall;
    [SerializeField] GameObject bridge;
    [SerializeField] CodeWizard codeWiz;

    // Called before the first frame update
    void Start() 
    {
        bridge.SetActive(false);
        pitfall.SetActive(true);
    }

    // Called when a collider enters this object's trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PuzzleObject"))
        {
            if (collider.gameObject == intBlock)
            {
                pitfall.SetActive(false);
                bridge.SetActive(true);
                stringBlock.SetActive(false);
            }
            else
            {
                if (codeWiz != null) 
                {
                    codeWiz.GiveHint
                    ("Nothing happened. That must have been the wrong variable!");
                }
            }
            LockInObject(collider.gameObject);
        }
    }
}
