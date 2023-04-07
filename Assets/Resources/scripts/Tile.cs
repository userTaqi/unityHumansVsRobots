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

    // Method to initialize the tile with a specific color
    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    // Method called when the tile is clicked
    public void OnMouseDown()
    {
        SpawnObject();
    }

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
    public void SpawnObject()
    {
        if (IsEmpty() && _canSpawnObject)
        {
            // Instantiate a new object prefab on the tile
            if (_objectPrefab == null)
            {
                Debug.LogWarning("Object prefab is null!");
                return;
            }
            var newObject = Instantiate(_objectPrefab, transform.position, Quaternion.identity);
            _objectOnTile = newObject;

            // Disable spawning on all other tiles
            var tileObjects = FindObjectsOfType<Tile>();
            foreach (var tileObject in tileObjects)
            {
                tileObject.SetCanSpawnObject(false);
            }

            // Check if the spawned object has the "scientist" tag and the player has enough points
            if (newObject.CompareTag("scientist") && FindObjectOfType<powerCellsPerSecond>().pointsAmount >= 15f)
            {
                FindObjectOfType<powerCellsPerSecond>().pointsAmount -= 15f;
            }
            else if (newObject.CompareTag("scientist") && FindObjectOfType<powerCellsPerSecond>().pointsAmount < 15f)
            {
                Debug.Log("Not enough points to spawn the scientist object!");
                Destroy(newObject);
                _objectOnTile = null;
                SetCanSpawnObject(true);
                return;
            }
        }
        else if (!IsEmpty() && _canRemoveObject)
        {
            // Remove the existing object from the tile
            Destroy(_objectOnTile);
            _objectOnTile = null;
            var tileObjects = FindObjectsOfType<Tile>();
            foreach (var tileObject in tileObjects)
            {
                tileObject.SetCanRemoveObject(false);
            }
        }
    }
}
