using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
    private int startingHealth = 100; // Starting health of the prefab
    private int currentHealth; // Current health of the prefab

    private int bulletDamage = 10;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            TakeDamage(bulletDamage); // You can change this value to adjust how much damage is dealt
        }
    }

    private void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // Destroy the prefab when it runs out of health
        }
    }
}
