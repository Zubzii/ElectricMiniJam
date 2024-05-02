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
            entityXPos = Mathf.Round(UnityEngine.Random.Range(tilemap.cellBounds.x + 10, tilemap.size.x + tilemap.cellBounds.x - 3));
            entityYPos = Mathf.Round(UnityEngine.Random.Range(tilemap.cellBounds.y + 3, tilemap.size.y + tilemap.cellBounds.y - 1));
            print("Cell grid size: (" + entityXPos + ", " + entityYPos + ")");
            print("Position: " + tilemap.CellToWorld(new Vector3Int((int)entityXPos, (int)entityYPos, 1)));
            Instantiate(enemy, tilemap.CellToWorld(new Vector3Int((int)entityXPos, (int)entityYPos, 1)), Quaternion.identity);
        }
    }
}
