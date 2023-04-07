using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] public GameObject _objectPrefab;
    private GameObject _objectOnTile;
    private bool _canSpawnObject = false;

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    public void OnMouseDown()
    {
        SpawnObject();
    }

    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    public bool IsEmpty()
    {
        return _objectOnTile == null;
    }

    public void SetCanSpawnObject(bool canSpawn)
    {
        _canSpawnObject = canSpawn;
    }

    public void SpawnObject()
    {
        if (IsEmpty() && _canSpawnObject)
        {
            if (_objectPrefab == null)
            {
                Debug.LogWarning("Object prefab is null!");
                return;
            }

            var newObject = Instantiate(_objectPrefab, transform.position, Quaternion.identity);
            _objectOnTile = newObject;

            var tileObjects = FindObjectsOfType<Tile>();
            foreach (var tileObject in tileObjects)
            {
                tileObject.SetCanSpawnObject(false);
            }
        }
        else if (!IsEmpty())
        {
            Destroy(_objectOnTile);
            _objectOnTile = null;
            SetCanSpawnObject(true);
        }
    }
}
