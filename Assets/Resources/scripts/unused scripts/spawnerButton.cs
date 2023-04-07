using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerButton : MonoBehaviour
{
    // Public variable that stores the prefab for the scientist object to be spawned
    public GameObject scientistPrefab;

    // Method to spawn a scientist object at the position of the spawner button
    public void SpawnIt(){
        Instantiate(scientistPrefab, transform.position, Quaternion.identity);
    }
}
