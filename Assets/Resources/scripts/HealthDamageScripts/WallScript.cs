using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float damageInterval = 2f;
    public int robotDamage = 20;

    private float timeSinceLastDamage;
    private bool isColliding = false;
    private Coroutine damageCoroutine;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("robot"))
        {
            isColliding = true;
            damageCoroutine = StartCoroutine(TakeDamage());
        }
        else if (collision.gameObject.CompareTag("robotDog"))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("robot"))
        {
            isColliding = false;
            StopCoroutine(damageCoroutine);
        }
    }

    IEnumerator TakeDamage()
    {
        while (isColliding)
        {
            yield return new WaitForSeconds(damageInterval);

            currentHealth -= robotDamage;

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                break;
            }
        }
    }
}
