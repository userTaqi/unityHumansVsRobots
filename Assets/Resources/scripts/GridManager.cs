using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height; // the size of the grid
    [SerializeField] private Tile _tilePrefab; // the prefab for each tile
    [SerializeField] private Transform _cam; // the camera
    private Tile[,] _tiles; // 2D array of tiles

    void Start() {
        GenerateGrid(); // generate the grid
    }

    // Generate the grid of tiles
    void GenerateGrid() {
        float cellSize = 1.5f; // change this value to adjust the cell size of the grid
        _tiles = new Tile[_width, _height]; // create the 2D array of tiles

        // loop through each cell in the grid and spawn a tile at that position
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x * cellSize, y * cellSize, 0.0f), Quaternion.identity); // spawn a tile at the current position
                spawnedTile.transform.localScale = new Vector3(cellSize, cellSize, 1.0f); // set the scale of the tile based on the desired cell size
                spawnedTile.name = $"Tile {x} {y}"; // name the tile for easier debugging

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0); // calculate whether the tile should be offset or not
                spawnedTile.Init(isOffset); // initialize the tile

                _tiles[x, y] = spawnedTile; // add the tile to the 2D array of tiles
            }
        }

        _cam.transform.position = new Vector3((float)(_width - 1) * cellSize / 2.0f, (float)(_height - 1) * cellSize / 2.0f, -10); // set the camera position
    }

    // Check whether an object can be placed at a specific tile
    public bool CanPlaceObjectAt(int x, int y) {
        if (x < 0 || x >= _width || y < 0 || y >= _height) {
            return false; // out of bounds, cannot place object
        }

        var tile = _tiles[x, y];
        return tile.IsEmpty(); // if the tile is empty, an object can be placed there
    }
}

