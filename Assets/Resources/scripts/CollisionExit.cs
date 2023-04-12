using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExit : MonoBehaviour
{
    public GameObject enemyPrefab;
    //Rigidbody2D rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionExit2D()
    {
        //rb.velocity = new Vector2(30f, rb.velocity.y);

        if(enemyPrefab.CompareTag("robot")){
            Rigidbody2D enemyRigidbody = enemyPrefab.GetComponent<Rigidbody2D>();
            enemyRigidbody.AddForce(transform.right * -30f);
        }
        
    }
}
