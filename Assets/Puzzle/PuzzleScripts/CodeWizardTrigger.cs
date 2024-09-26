using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Ville Kaikkonen
Triggers the code wizard with a message when interacted with
*/
public class CodeWizardTrigger : MonoBehaviour
{
    [SerializeField] bool triggersOnce;
    [SerializeField] string message;
    [SerializeField] CodeWizard codeWiz;
    int triggerCounter = 0;

    // Called when a collider enters this object's trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && triggerCounter == 0)
        {
            if (triggersOnce) { triggerCounter++; }
            if (message != null) { codeWiz.GiveHint(message); }
        }
    }
}
