using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("robot"))
        {
            Destroy(gameObject); // Destroy the bullet only when it collides with an object with the "Robot" tag
        }
    }
}
