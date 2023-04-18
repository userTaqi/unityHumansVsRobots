using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficerShooting : MonoBehaviour
{
    [SerializeField] GameOver script;
    [SerializeField] private GameObject bulletPrefab;  // the prefab of the bullet to shoot
    private float bulletSpeed = 4f;  // the speed at which to shoot the bullet
    private float shootInterval = 2f; // the time between shots
    private float shootingRange = 100f; // the range within which to detect enemies

    private float timeSinceLastShot = 0f;

    private void Start()
    {
        script = GameObject.FindWithTag("base").GetComponent<GameOver>();
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        // check if it's time to shoot again
        if (timeSinceLastShot >= shootInterval && script.gameAlive)
        {
            // Check if there is an enemy with tag "robot" in front
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.right, shootingRange);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null && hit.collider.CompareTag("robot"))
                {
                    Shoot();
                    break;
                }
            }
            timeSinceLastShot = 0f;
        }
    }

    private void Shoot()
    {
        // instantiate the bullet prefab
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // shoot the bullet to the right
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;

        //destroy prefab after 10 seconds
        Destroy(bullet, 10);
    }
}
