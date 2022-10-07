using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpMoveDown : MonoBehaviour
{
    private bool Alive = true;
    float PLAYER_SPEED = 0.125f;

    private void FixedUpdate() {
        if (Alive)
        {
            // float moveX = 0;
            // float moveY = 0;
            // moveX += 0.2f;
            // moveY -= 0.1f;
            // if (Input.GetKey(KeyCode.Space)) moveY *= -2f;
            // Vector2 newVelocity = new Vector2(moveX, moveY) * PLAYER_SPEED;
            // GetComponent<Rigidbody>().velocity = newVelocity;
        } 
    }
}
