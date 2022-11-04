using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class Collision : MonoBehaviour
// {
//     //create a reference to the Health script
//     public Health health;
//     // Start is called before the first frame update
//     void Start()
//     {
//         //get the Health script and store it in a variable we can use
//         health = GetComponent<Health>();
//     }
//     //when enemy object collides with player
//     void OnCollisionEnter2D(Collision2D collision)
//     {
//         //if the object that collided with the enemy is the player
//         if (collision.gameObject.tag == "Enemy")
//         {
//             //call the TakeDamage function from the Health script
//             health.TakeDamage(1);
//         }
//     }
// }