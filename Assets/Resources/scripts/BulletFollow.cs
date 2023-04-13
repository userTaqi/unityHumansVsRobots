using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollow : MonoBehaviour
{
    [SerializeField] GameOver script;
    [SerializeField] private GameObject bulletPrefab;  // the prefab of the bullet to shoot
    private float bulletSpeed = 30f;  // the speed at which to shoot the bullet
    private float shootInterval = 0.5f; // the time between shots

    private float timeSinceLastShot = 0f;

    private void Start()
    {
        script = GameObject.FindWithTag("base").GetComponent<GameOver>();
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        // check if it's time to shoot again and if a drone exists
        if (timeSinceLastShot >= shootInterval && script.gameAlive && GameObject.FindGameObjectWithTag("drone") != null)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }
    }

    private void Shoot()
    {
        // find the closest object with the "drone" tag
        GameObject closestDrone = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject drone in GameObject.FindGameObjectsWithTag("drone"))
        {
            float distance = Vector2.Distance(transform.position, drone.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestDrone = drone;
            }
        }

        // instantiate the bullet prefab
        GameObject bullet = Instantiate(bulletPrefab, transform.position + Vector3.up, Quaternion.identity);

        // shoot the bullet to follow the closest drone
        if (closestDrone != null)
        {
            Vector2 direction = (closestDrone.transform.position - transform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
        else // if there are no drones, shoot to the right
        {
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;
        }

        //destroy prefab after 10 seconds
        Destroy(bullet, 10);
    }
}
