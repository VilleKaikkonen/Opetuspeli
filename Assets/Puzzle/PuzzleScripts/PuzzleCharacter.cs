using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Ville Kaikkonen
Controls the character's movements in the game.
*/
public class PuzzleCharacter : MonoBehaviour
{
    Transform characterTransform;
    [Range(1, 30)][SerializeField] float moveSpeed;
    bool controlsActive;
    GameManager gameManager;
    [SerializeField] AudioClip scream;
    // Separation by William King
    [SerializeField] AudioClip puzzleMusic;

    // Handles character controls
    IEnumerator Controller()
    {
        do {
            float x = characterTransform.localPosition.x;
            float y = characterTransform.localPosition.y;

            if (Input.GetKey("up") && !Input.GetKey("down"))
            {
                // Debug.Log("The character moves up.");
                y = y + (Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey("down") && !Input.GetKey("up"))
            {
                // Debug.Log("The character moves down.");
                y = y - (Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey("right") && !Input.GetKey("left"))
            {
                // Debug.Log("The character moves right.");
                x = x + (Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey("left") && !Input.GetKey("right"))
            {
                // Debug.Log("The character moves left.");
                x = x - (Time.deltaTime * moveSpeed);
            }

            characterTransform.localPosition = new Vector2(x, y);
            
            yield return new WaitForEndOfFrame();

        } while (controlsActive);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (puzzleMusic != null) { gameManager.PlayMusic(puzzleMusic); }
        if (characterTransform == null) { characterTransform = GetComponent<Transform>(); }
        controlsActive = true;
        StartCoroutine("Controller");
    }

    // Used to set control's active state
    public void SetControlsActivity(bool t) 
    { 
        controlsActive = t; 
        if (t == true) { StartCoroutine("Controller"); }
    }

    // Called when the character falls to their death
    public void Death()
    {
        SetControlsActivity(false);
        GetComponent<PuzzleCharacter>().SetControlsActivity(false);
        GetComponent<SpriteRenderer>().color = Color.clear;
        if (scream != null) 
        { 
            if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
            gameManager.PlaySound(scream); 
        }
    }
}
