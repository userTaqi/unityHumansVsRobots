using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // the prefab of the bullet to shoot
    public float bulletSpeed = 10f;  // the speed at which to shoot the bullet
    public float shootInterval = 1f; // the time between shots

    private float timeSinceLastShot = 0f;

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        // check if it's time to shoot again
        if (timeSinceLastShot >= shootInterval)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }
    }

    private void Shoot()
    {
        // instantiate the bullet prefab
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // shoot the bullet to the right
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;
    }
}
