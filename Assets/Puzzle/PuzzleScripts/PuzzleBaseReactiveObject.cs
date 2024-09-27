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
        Destroy(objectToLock.GetComponent<Rigidbody2D>());
        Destroy(objectToLock.GetComponent<BoxCollider2D>());
        this.gameObject.SetActive(false);
    }
}
