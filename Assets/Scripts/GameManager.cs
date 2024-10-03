using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Authors: Ville Kaikkonen
Game Manager handles information across different scenes.
*/

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    AudioSource soundPlayer;

    // Awake is called when the script is loaded
    void Awake() {
        if (gameManager == null)
        {
            // If there is no Game Manager, this will be the main one
            gameManager = this;
            DontDestroyOnLoad(this);
        } else if (gameManager != this)
        {
            // If there is a Game Manager already, destroy this one
            Destroy(gameObject);
        }
    }

    // Loads a scene by its ID in scene hierarchy
    public void LoadScene(int sceneID) { SceneManager.LoadScene(sceneID); }

    // Loads a scene by its name
    public void LoadScene(string sceneName) { SceneManager.LoadScene(sceneName); }

    // Starts to play an audioclip on loop, unless its already playing
    public void PlayMusic(AudioClip music) 
    {
        if (soundPlayer == null) soundPlayer = GetComponent<AudioSource>();

        if (music != soundPlayer.clip)
        {
            if (soundPlayer.isPlaying) soundPlayer.Pause();

            soundPlayer.loop = true;
            soundPlayer.clip = music;
        }

        if (!soundPlayer.isPlaying) soundPlayer.Play();
    }

    // Stops the currently playing music if any
    public void PauseMusic() { soundPlayer.Pause(); }

    // Plays an audioclip once, without interrupting music
    public void PlaySound(AudioClip sound)
    {
        if (soundPlayer == null) soundPlayer = GetComponent<AudioSource>();
        soundPlayer.PlayOneShot(sound); 
    }
}
