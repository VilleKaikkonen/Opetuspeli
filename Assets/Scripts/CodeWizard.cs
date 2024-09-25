using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
Author: Ville Kaikkonen
Handles hint texts for different scenes and how the code wizard (dis)appears
*/
public class CodeWizard : MonoBehaviour
{
    [SerializeField] TMP_Text speech;
    [SerializeField] Image wizImage;
    [SerializeField] Image bubbleImage;

    // Sets a timer, during which the code wizard is visible
    IEnumerator CodeWizardActive()
    {
        SetVisibility(true);
        yield return new WaitForSeconds(10f);
        SetVisibility(false);
    }

    // Invokes the code wizard, who provides a hint based on a given string
    public void GiveHint(string hintText)
    {
        StopCoroutine("CodeWizardActive");
        if (speech == null) speech = GetComponentInChildren<TMP_Text>();
        StartCoroutine("CodeWizardActive");
        speech.text = hintText;
    }

    // Sets the visibility of the code wizard and its children
    void SetVisibility(bool visible)
    {
        if (visible) 
        { 
            wizImage.color = Color.white;
            bubbleImage.color = Color.white;
            speech.color = new Color32(0, 0, 0, 255); 
        }
        else 
        { 
            Color32 newColor = new Color32(0, 0, 0, 0);
            wizImage.color = newColor;
            bubbleImage.color = newColor;
            speech.color = newColor;  
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        /*
        wizImage = GetComponent<Image>();
        bubbleImage = GetComponentInChildren<Image>();
        */
        if (speech == null) speech = GetComponentInChildren<TMP_Text>();
        SetVisibility(false);
    }
}
