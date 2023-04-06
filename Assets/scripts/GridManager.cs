using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
 
    [SerializeField] private Tile _tilePrefab;
 
    [SerializeField] private Transform _cam;

    void Start() {
        GenerateGrid();
    }

    void GenerateGrid() {
        float cellSize = 1.5f; // change this value to adjust the cell size of the grid

        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x * cellSize, y * cellSize, 0.0f), Quaternion.identity);
                spawnedTile.transform.localScale = new Vector3(cellSize, cellSize, 1.0f); // set the scale of the tile based on the desired cell size
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
            }
        }

        _cam.transform.position = new Vector3((float)(_width - 1) * cellSize / 2.0f, (float)(_height - 1) * cellSize / 2.0f, -10);
    }


}
