using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("base")) {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("base")) {
            Destroy(gameObject);
        }
    }
}

