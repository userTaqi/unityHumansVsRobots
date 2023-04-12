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
        float cellWidth = 2.1f; // change this value to adjust the cell width of the grid
        float cellHeight = 1.9f; // change this value to adjust the cell height of the grid
        _tiles = new Tile[_width, _height]; // create the 2D array of tiles

        // loop through each cell in the grid and spawn a tile at that position
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x * cellWidth, y * cellHeight, -5.0f), Quaternion.identity); // spawn a tile at the current position
                spawnedTile.transform.localScale = new Vector3(cellWidth, cellHeight, 1.0f); // set the scale of the tile based on the desired cell size
                spawnedTile.name = $"Tile {x} {y}"; // name the tile for easier debugging

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0); // calculate whether the tile should be offset or not
                spawnedTile.Init(isOffset); // initialize the tile

                _tiles[x, y] = spawnedTile; // add the tile to the 2D array of tiles
            }
        }

        _cam.transform.position = new Vector3((float)(_width - 1) * cellWidth / 2.0f, (float)(_height - 0.1) * cellHeight / 2.0f, -10); // set the camera position
    }

}

