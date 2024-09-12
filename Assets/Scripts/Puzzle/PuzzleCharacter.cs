using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCharacter : MonoBehaviour
{
    Transform characterTransform;
    float moveSpeed = 3f;
    bool controlsActive;

    // Handles character controls
    IEnumerator Controller()
    {
        do {
            float x = characterTransform.localPosition.x;
            float y = characterTransform.localPosition.y;

            if (Input.GetKey("up") && !Input.GetKey("down"))
            {
                // Debug.Log("The character moves up.");
                // characterPosition = new Vector2(x, y + (Time.deltaTime * moveSpeed));
                y = y + (Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey("down") && !Input.GetKey("up"))
            {
                // Debug.Log("The character moves down.");
                // characterPosition = new Vector2(x, y - (Time.deltaTime * moveSpeed));
                y = y - (Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey("right") && !Input.GetKey("left"))
            {
                // Debug.Log("The character moves right.");
                // characterPosition = new Vector2(x + (Time.deltaTime * moveSpeed), y);
                x = x + (Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey("left") && !Input.GetKey("right"))
            {
                // Debug.Log("The character moves left.");
                // characterPosition = new Vector2(x - (Time.deltaTime * moveSpeed), y);
                x = x - (Time.deltaTime * moveSpeed);
            }

            characterTransform.localPosition = new Vector2(x, y);
            
            yield return new WaitForEndOfFrame();

        } while (controlsActive);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (characterTransform == null) { characterTransform = GetComponent<Transform>(); }
        controlsActive = true;
        StartCoroutine("Controller");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Is used to set control's active state
    public void SetControlsActivity(bool t) { controlsActive = t; }
}
