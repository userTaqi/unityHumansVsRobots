using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Private variables that control the appearance of the tile
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    // Public variable that stores the prefab for objects that can be spawned on this tile
    [SerializeField] public GameObject _objectPrefab;

    // Private variables that store information about objects currently on the tile
    private GameObject _objectOnTile;
    private bool _canSpawnObject = false;
    private bool _canRemoveObject = false;

    //variables for diff card prices
    private float scientistPrice= 20f;
    private float soldierPrice= 15f;

    // Method to initialize the tile with a specific color
    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    // Method called when the tile is clicked
    public void OnMouseDown()
    {
        SpawnObject(_objectPrefab);
    }
    
    /*
    // Method called when the mouse enters the tile's area
    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    // Method called when the mouse exits the tile's area
    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
    */

    // Method to check if there is an object on the tile
    public bool IsEmpty()
    {
        return _objectOnTile == null;
    }

    public void SetCanSpawnObject(bool canSpawn)
    {
        _canSpawnObject = canSpawn;
        if (_canSpawnObject && _canRemoveObject)
        {
            _canRemoveObject = false;
        }
    }

    public void SetCanRemoveObject(bool canRemove)
    {
        _canRemoveObject = canRemove;
        if (_canSpawnObject && _canRemoveObject)
        {
            _canSpawnObject = false;
        }
    }

    // Method to spawn an object on the tile, or remove the existing object if one is present
    public void SpawnObject(GameObject prefab)
    {
        if (IsEmpty() && _canSpawnObject)
        {
            // Instantiate a new object prefab on the tile
            if (prefab == null)
            {
                Debug.LogWarning("Object prefab is null!");
                return;
            }
            
            // Set the position of the new object to (x, y, 1.0) to ensure a Z position of 1.0
            Vector3 newPosition = transform.position;
            newPosition.z = 1.0f;
            var newObject = Instantiate(prefab, newPosition, Quaternion.identity);
            _objectOnTile = newObject;

            // Disable spawning on all other tiles
            var tileObjects = FindObjectsOfType<Tile>();
            foreach (var tileObject in tileObjects)
            {
                tileObject.SetCanSpawnObject(false);
            }

            // Check if the spawned object has the "scientist" tag and the player has enough points
            if (newObject.CompareTag("scientist") && FindObjectOfType<powerCellsPerSecond>().pointsAmount >= scientistPrice)
            {
                FindObjectOfType<powerCellsPerSecond>().pointsAmount -= scientistPrice;
            }
            else if (newObject.CompareTag("scientist") && FindObjectOfType<powerCellsPerSecond>().pointsAmount < scientistPrice)
            {
                Debug.Log("Not enough points to spawn the scientist object!");
                Destroy(newObject);
                _objectOnTile = null;
                SetCanSpawnObject(true);
                return;
            }
            else if (newObject.CompareTag("soldier") && FindObjectOfType<powerCellsPerSecond>().pointsAmount >= soldierPrice)
            {
                FindObjectOfType<powerCellsPerSecond>().pointsAmount -= soldierPrice;
            }
            else if (newObject.CompareTag("soldier") && FindObjectOfType<powerCellsPerSecond>().pointsAmount < soldierPrice)
            {
                Debug.Log("Not enough points to spawn the soldier object!");
                Destroy(newObject);
                _objectOnTile = null;
                SetCanSpawnObject(true);
                return;
            }
        }
        else if (!IsEmpty() && _canSpawnObject){
            Debug.Log("Tile is occupied");
            var tileObjects = FindObjectsOfType<Tile>();
            foreach (var tileObject in tileObjects)
            {
                tileObject.SetCanSpawnObject(false);
            }
        }
        else if (!IsEmpty() && _canRemoveObject)
        {
            // Remove the existing object from the tile
            Destroy(_objectOnTile);
            _objectOnTile = null;

            // Add half of the points of the removed object back to the pointsAmount variable
            var powerCellsScript = FindObjectOfType<powerCellsPerSecond>();
            powerCellsScript.pointsAmount += scientistPrice / 2f;

            var tileObjects = FindObjectsOfType<Tile>();
            foreach (var tileObject in tileObjects)
            {
                tileObject.SetCanRemoveObject(false);
            }
        }
        else if (IsEmpty() && _canRemoveObject)
        {
            Debug.Log("Tile is empty");
            var tileObjects = FindObjectsOfType<Tile>();
            foreach (var tileObject in tileObjects)
            {
                tileObject.SetCanRemoveObject(false);
            }
        }
    }


}
