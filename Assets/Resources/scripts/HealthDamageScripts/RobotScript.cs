using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
    private int startingHealth = 100; // Starting health of the prefab
    private int currentHealth; // Current health of the prefab
    private int bulletDamage = 10;
    private int spikesDamage = 5;

    private float spikeTimer = 0f;
    private float spikeInterval = 2f; // Spike damage interval in seconds

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("spikes"))
        {
            // Increment the timer and check if it's time to take spike damage again
            spikeTimer += Time.deltaTime;
            if (spikeTimer >= spikeInterval)
            {
                TakeDamage(spikesDamage);
                spikeTimer = 0f; // Reset the timer
            }
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
