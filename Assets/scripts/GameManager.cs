using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject scientistPrefab; // Reference to the scientist prefab

    public void EnableSpawn()
    {
        var tileObjects = FindObjectsOfType<Tile>();
        foreach (var tileObject in tileObjects)
        {
            tileObject.SetCanSpawnObject(true);
        }
    }

    public void SetObjectPrefabToScientist()
    {
        // Load the scientist prefab dynamically from Resources folder
        scientistPrefab = Resources.Load<GameObject>("prefabs/scientist");

        if (scientistPrefab != null)
        {
            foreach (var tileObject in FindObjectsOfType<Tile>())
            {
                tileObject._objectPrefab = scientistPrefab;
            }
        }
    }
}
