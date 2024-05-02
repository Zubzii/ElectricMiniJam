using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;
using System.Collections.Generic;

public class HealthPackSpawner : MonoBehaviour
{
    public GameObject healthPack;
    public float spawnTime = 15f;
    public Tilemap tilemap;
    private float entityXPos;
    private float entityYPos;

    void Start()
    {
        InvokeRepeating("SpawnHealthPack", spawnTime, spawnTime);
    }

    void SpawnHealthPack()
    {
        entityXPos = Mathf.Round(UnityEngine.Random.Range(tilemap.cellBounds.x + 10, tilemap.size.x + tilemap.cellBounds.x - 3));
        entityYPos = Mathf.Round(UnityEngine.Random.Range(tilemap.cellBounds.y + 3, tilemap.size.y + tilemap.cellBounds.y - 3));
        
        Vector3Int spawnPosition = new Vector3Int((int)entityXPos, (int)entityYPos, 1);

        Instantiate(healthPack, tilemap.CellToWorld(spawnPosition), Quaternion.identity);
    }
}
