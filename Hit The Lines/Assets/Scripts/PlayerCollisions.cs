using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionsAndHea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        // ObjectPool.DisableStarAndAddToQueue(other.gameObject);
        other.gameObject.GetComponent<LineRenderer>().enabled = false;

        Debug.Log("Point Received");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Decrease Life");
        }
    }
}
