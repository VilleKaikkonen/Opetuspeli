using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Ville Kaikkonen
Works as a base for other reactive objects in the puzzles
*/
public class PuzzleBaseReactiveObject : MonoBehaviour
{
    // Locks an object in this one's place and deactivates itself
    public void LockInObject(GameObject objectToLock)
    {
        objectToLock.GetComponent<Transform>().localPosition
        = GetComponent<Transform>().localPosition;
        objectToLock.GetComponent<Rigidbody2D>().bodyType 
        = RigidbodyType2D.Kinematic;
        this.gameObject.SetActive(false);
    }
}
