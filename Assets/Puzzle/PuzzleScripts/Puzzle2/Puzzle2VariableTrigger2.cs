using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Ville Kaikkonen
A trigger for pushable objects, that determines if the puzzle is a success
*/
public class PuzzleBlockTrigger : PuzzleBaseReactiveObject
{
    [SerializeField] GameObject correctBlock;
    [SerializeField] GameObject[] wrongBlocks = new GameObject[1];
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject pathForward;
    [SerializeField] CodeWizard codeWiz;
    [SerializeField] string hintWrong;
    [SerializeField] string hintRight;

    // Start is called before the first frame update
    void Start()
    {
        obstacle.SetActive(true);
        pathForward.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PuzzleObject"))
        {
            if (collider.gameObject == correctBlock)
            {
                obstacle.SetActive(false);
                pathForward.SetActive(true);
                
                foreach (GameObject block in wrongBlocks)
                {
                    block.SetActive(false);
                }

                if (codeWiz != null) { codeWiz.GiveHint(hintRight); }
            }
            else
            {
                if (codeWiz != null) { codeWiz.GiveHint(hintWrong); }
            }

            LockInObject(collider.gameObject);
        }
    }
}
