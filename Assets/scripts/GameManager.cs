using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void EnableSpawn() {
        var tileObjects = FindObjectsOfType<Tile>();
        foreach (var tileObject in tileObjects) {
            tileObject.SetCanSpawnObject(true);
        }
    }
}
