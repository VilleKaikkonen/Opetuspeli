using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Authors: Ville Kaikkonen
Main Menu handles all the events in the "Main Menu" scene.
*/

public class MainMenu : MonoBehaviour
{
    public GameManager gameManager;


    // Start-button function that starts the game
    public void StartGame()
    {
        gameManager.LoadScene("GladiatorScene");
    }

    public void QuitGame() { Application.Quit(); }
}
