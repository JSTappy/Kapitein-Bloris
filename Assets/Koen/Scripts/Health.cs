using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    virtual public void TakeDamage(int damage)
    {
        health -= damage;
        healthbar.SetHealth(health);
    }

    //update take damage when space bar is pressed
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}