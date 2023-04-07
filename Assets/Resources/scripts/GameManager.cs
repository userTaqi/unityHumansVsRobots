using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject scientistPrefab; // Reference to the scientist prefab

    // Enable the ability to spawn objects on all the tiles
    public void EnableSpawn()
    {
        var tileObjects = FindObjectsOfType<Tile>(); // Find all the Tile objects in the scene
        foreach (var tileObject in tileObjects)
        {
            tileObject.SetCanSpawnObject(true); // Set the CanSpawnObject flag to true on each tile
        }
    }

    public void EnableRemove()
    {
        var tileObjects = FindObjectsOfType<Tile>(); // Find all the Tile objects in the scene
        foreach (var tileObject in tileObjects)
        {
            tileObject.SetCanRemoveObject(true); // Set the CanRemoveObject flag to true on each tile
        }
    }

    // Set the object prefab to the scientist prefab for all tiles
    public void SetObjectPrefabToScientist()
    {
        // Load the scientist prefab dynamically from Resources folder
        scientistPrefab = Resources.Load<GameObject>("prefabs/scientist");

        if (scientistPrefab != null)
        {
            foreach (var tileObject in FindObjectsOfType<Tile>())
            {
                tileObject._objectPrefab = scientistPrefab; // Set the object prefab to the scientist prefab on each tile
            }
        }
    }
}
