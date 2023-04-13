using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawnManager : MonoBehaviour
{
    private GameObject scientistPrefab; // Reference to the scientist prefab
    private GameObject soldierPrefab;
    private GameObject wallPrefab;
    private GameObject sniperPrefab;
    private GameObject spikesPrefab;

    // Enable the ability to spawn objects on all the tiles
    public void EnableSpawn()
    {
        var tileObjects = FindObjectsOfType<Tile>(); // Find all the Tile objects in the scene
        foreach (var tileObject in tileObjects)
        {
            tileObject.SetCanSpawnObject(true); // Set the CanSpawnObject flag to true on each tile
        }
    }

    // Enable the ability to remove objects on all the tiles
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
        scientistPrefab = Resources.Load<GameObject>("prefabs/allies/scientist");

        if (scientistPrefab != null)
        {
            foreach (var tileObject in FindObjectsOfType<Tile>())
            {
                tileObject._objectPrefab = scientistPrefab; // Set the object prefab to the scientist prefab on each tile
            }
        }
    }

    // Set the object prefab to the soldier prefab for all tiles
    public void SetObjectPrefabToSoldier()
    {
        // Load the soldier prefab dynamically from Resources folder
        soldierPrefab = Resources.Load<GameObject>("prefabs/allies/officer");

        if (soldierPrefab != null)
        {
            foreach (var tileObject in FindObjectsOfType<Tile>())
            {
                tileObject._objectPrefab = soldierPrefab; // Set the object prefab to the scientist prefab on each tile
            }
        }
    }

    public void SetObjectPrefabToWall()
    {
        // Load the soldier prefab dynamically from Resources folder
        wallPrefab = Resources.Load<GameObject>("prefabs/allies/wall");

        if (wallPrefab != null)
        {
            foreach (var tileObject in FindObjectsOfType<Tile>())
            {
                tileObject._objectPrefab = wallPrefab; // Set the object prefab to the scientist prefab on each tile
            }
        }
    }

    public void SetObjectPrefabToSniper()
    {
        // Load the soldier prefab dynamically from Resources folder
        sniperPrefab = Resources.Load<GameObject>("prefabs/allies/sniper");

        if (sniperPrefab != null)
        {
            foreach (var tileObject in FindObjectsOfType<Tile>())
            {
                tileObject._objectPrefab = sniperPrefab; // Set the object prefab to the sniper prefab on each tile
            }
        }
    }

    public void SetObjectPrefabToSpikes()
    {
        // Load the soldier prefab dynamically from Resources folder
        spikesPrefab = Resources.Load<GameObject>("prefabs/allies/spikes");

        if (spikesPrefab != null)
        {
            foreach (var tileObject in FindObjectsOfType<Tile>())
            {
                tileObject._objectPrefab = spikesPrefab; // Set the object prefab to the spikes prefab on each tile
            }
        }
    }
}
