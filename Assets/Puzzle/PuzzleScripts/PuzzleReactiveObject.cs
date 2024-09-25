using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Author: Ville Kaikkonen
A collider testing script
*/
public class PuzzleReactiveObject : MonoBehaviour
{
    [SerializeField] CodeWizard codeWizard;

    // Called when a collider enters this object's trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PuzzleObject"))
        {
            Debug.Log(collider.gameObject.name);
            if (codeWizard == null) 
            { 
                bool foundWizard = TryGetComponent<CodeWizard>(out CodeWizard wizard);
                if (foundWizard) { codeWizard = wizard; }
            }
            
            if (codeWizard != null) { codeWizard.GiveHint(collider.gameObject.name); }
            else { Debug.Log("Code wizard is missing!"); }
        }
    }
}
