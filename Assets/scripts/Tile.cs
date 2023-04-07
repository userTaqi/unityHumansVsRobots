using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
   [SerializeField] private Color _baseColor, _offsetColor;
   [SerializeField] private SpriteRenderer _renderer;
   [SerializeField] private GameObject _highlight;
   [SerializeField] private GameObject _objectPrefab;
   [SerializeField] private GameObject _currentObject;

   private GameObject _placedObject;

    public void Init(bool isOffset) {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    void OnMouseEnter(){
        _highlight.SetActive(true);
    }

    void OnMouseExit(){
        _highlight.SetActive(false);
    }

    public bool IsEmpty() {
        return _placedObject == null;
    }

    void OnMouseDown() {
        if (_currentObject != null) {
            Destroy(_currentObject);
            _currentObject = null;
        } else {
            var spawnedObject = Instantiate(_objectPrefab, transform.position, Quaternion.identity);
            spawnedObject.name = $"Object on Tile {transform.position}";
            _currentObject = spawnedObject;
        }
    }
}
