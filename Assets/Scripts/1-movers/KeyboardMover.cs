using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class KeyboardMover: MonoBehaviour {
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 1f;
    [SerializeField] KeyCode Up = KeyCode.W;
    [SerializeField] KeyCode Down = KeyCode.S;
    [SerializeField] KeyCode Left = KeyCode.A;
    [SerializeField] KeyCode Right = KeyCode.D;
    
    //Used for both firing and displaying sprites and is set when key is pressed
    public string playerRotation;


    void Update()
    {

        //Didn't use Horizontal or Vertical because I wanted to sperate contols for different players.
        //Same script is used as different keys can be assigned.

        Vector3 movementVector = transform.position;
        if (Input.GetKey(Up))
        {
            movementVector.y += speed * Time.deltaTime;
            transform.position = movementVector;
            playerRotation = "up";
        }
        if (Input.GetKey(Down))
        {
            movementVector.y -= speed * Time.deltaTime;
            transform.position = movementVector;
            playerRotation = "down";
        }
        if (Input.GetKey(Left))
        {
            movementVector.x -= speed * Time.deltaTime;
            transform.position = movementVector;
            playerRotation = "left";
        }
        if (Input.GetKey(Right))
        {
            movementVector.x += speed * Time.deltaTime;
            transform.position = movementVector;
            playerRotation = "right";
        }
    }
}
