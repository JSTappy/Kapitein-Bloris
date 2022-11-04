using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    private HealtBar healthbar;

    void Start()
    {
        healthbar = GameObject.Find("HealthBar").GetComponent<HealtBar>();
        health = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        healthbar.SetHealth(health);
    }

    //update take damage when space bar is pressed
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }
}