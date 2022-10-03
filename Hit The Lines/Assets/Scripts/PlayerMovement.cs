using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    [SerializeField, Range(0, 10)] private float forcePower = 5;
    private Vector3 _touchStart, _touchEnd;
    private Vector2 forceVector;
    private Rigidbody2D playerRigidbody;
    private void Start() {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
    }
    private void Update() {
        if(Input.GetMouseButtonDown(0))
        {
            _touchStart = Input.mousePosition; // Get the first touch and assign
        }

        if(Input.GetMouseButtonUp(0))
        {
            _touchEnd = Input.mousePosition; // Get the touch-release point and assign 
            forceVector =  _touchEnd - _touchStart; // Calculate the Vector2 created by Drag Event.
            playerRigidbody.velocity = Vector2.zero; // In every drag event, we want a new movement. This line removes previous forces, velocities.
            ApplyForceToPlayer();
        }
    }

    private void ApplyForceToPlayer()
    {
        if(!GameManager.Instance.isGamePaused)
            playerRigidbody.AddForce(forceVector * forcePower); // Apply the force to the Rigidbody.
    }

    
}
