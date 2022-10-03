using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool Alive = true;

    const float PLAYER_SPEED = 5;

    void Update()
    {
        
    }

    private void FixedUpdate() {
        if (Alive)
        {

            float moveX = 0;
            float moveY = 0;
            if (Input.GetKey(KeyCode.D)) moveX += 1;
            if (Input.GetKey(KeyCode.A)) moveX -= 1;
            if (Input.GetKey(KeyCode.W)) moveY += 1;
            if (Input.GetKey(KeyCode.S)) moveY -= 1;
            Vector2 newVelocity = new Vector2(moveX, moveY) * PLAYER_SPEED;
            

            GetComponent<Rigidbody>().velocity = newVelocity;
        } 
    }
}
