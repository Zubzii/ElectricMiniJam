using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject ground;
    public Tilemap tilemap;

    public GameObject enemy;

    public int spawnCount;
    

    private float entityXPos;
    private float entityYPos;
    
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < spawnCount; i++)
        {
            // print("Grid size: (" + tilemap.cellBounds.x + ", " + tilemap.cellBounds.y + ")");
            entityXPos = Mathf.Round(UnityEngine.Random.Range(tilemap.cellBounds.x, tilemap.size.x + tilemap.cellBounds.x));
            entityYPos = Mathf.Round(UnityEngine.Random.Range(tilemap.cellBounds.y, tilemap.size.y + tilemap.cellBounds.y));
            // print("Cell Size: " + tilemap.cellBounds);
            // print("Position: (" + entityXPos + ", " + entityYPos + ")");
            Instantiate(enemy, tilemap.CellToWorld(new Vector3Int((int)entityXPos, (int)entityYPos, 1)), Quaternion.identity);
        }

    }
}
