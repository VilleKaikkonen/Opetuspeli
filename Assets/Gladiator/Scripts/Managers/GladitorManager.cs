using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Author: Antti Sironen
 */

public class GladitorManager : MonoBehaviour
{
    public static GladitorManager Instance { get; private set; } // Singleton

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of GladiatorManager found!" + Instance + transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

}
