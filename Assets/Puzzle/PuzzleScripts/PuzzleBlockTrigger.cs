using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
Author: Ville Kaikkonen
A trigger for pushable objects, that determines if the puzzle is a success
*/
public class PuzzleBlockTrigger : PuzzleBaseReactiveObject
{
    // List of blocks that provide a correct answer for this trigger
    [SerializeField] GameObject[] correctBlocks = new GameObject[1];
    // List of blocks that provide a wrong answer for this trigger
    [SerializeField] GameObject[] wrongBlocks = new GameObject[1];
    // List of triggers used in the same part of the puzzle
    [SerializeField] PuzzleBlockTrigger[] siblingTriggers 
    = new PuzzleBlockTrigger[0];
    // List of obstacles that will be deactivated for progression
    [SerializeField] GameObject[] obstacles = new GameObject[1];
    // List of obstacles that will be activated for progression
    [SerializeField] GameObject[] pathsForward = new GameObject[0];
    // An instance of a code wizard, that will provide clues etc.
    [SerializeField] CodeWizard codeWiz;
    // A message that is shown when the solution was wrong
    [SerializeField] string hintWrong;
    // A message that is shown when the soliton was correct
    [SerializeField] string hintRight;
    // Counts progress towards full solution
    int correctBlocksInPlace = 0;
    bool triggerEmpty = true;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obstacle in obstacles) { obstacle.SetActive(true); }
        foreach (GameObject path in pathsForward) { path.SetActive(false); }
    }

    // Called to update the situation among sibling triggers
    public void GotCorrectBlock() { correctBlocksInPlace++; }

    // Called when a collider enters this object's trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PuzzleObject") && triggerEmpty)
        {

            if (correctBlocks.Contains(collider.gameObject))
            {
                Debug.Log("Got correct block.");
                GotCorrectBlock();
                foreach (PuzzleBlockTrigger sibling in siblingTriggers)
                { sibling.GotCorrectBlock(); }

                if (correctBlocksInPlace > siblingTriggers.Length)
                {
                    foreach (GameObject obstacle in obstacles) 
                    { obstacle.SetActive(false); }

                    foreach (GameObject path in pathsForward) 
                    { path.SetActive(true); }
                
                    foreach (GameObject block in wrongBlocks)
                    { block.SetActive(false); }

                    if (codeWiz != null) { codeWiz.GiveHint(hintRight); }
                }
            }
            else
            {
                Debug.Log("Got wrong block.");
                if (codeWiz != null) { codeWiz.GiveHint(hintWrong); }

                foreach (GameObject block in wrongBlocks)
                {
                    if (block != collider.gameObject)
                    { block.SetActive(false); }
                }

                foreach (GameObject block in correctBlocks)
                { block.SetActive(false); }
            }
                triggerEmpty = false;
                LockInObject(collider.gameObject);
        }
    }
}
