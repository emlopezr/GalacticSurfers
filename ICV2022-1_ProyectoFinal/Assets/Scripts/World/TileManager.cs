using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private GameObject[] canyonPrefabs;
    [SerializeField] private GameObject[] buildingPrefabs;
    [SerializeField] private int tilesCharged = 5;
    private List<GameObject> activeTiles = new List<GameObject>();
    private float zSpawn = 0;
    private float tileLenght = 30;
    private bool inBuilding = false;

    [SerializeField] private Transform player;

    private void Start()
    {
        // Las primeras 2 son sin obstáculos y de tipo canyon
        SpawnTile(0, false);
        SpawnTile(0, false);

        // Spawnear las otras iniciales
        for (int i=2; i<tilesCharged; i++)
        {
            SpawnTile(Random.Range(1, canyonPrefabs.Length-1), false);
        }
    }

    private void Update()
    {
        if(player.transform.position.z - 60 > zSpawn - (tilesCharged * tileLenght))
        {
            // Generar las tiles
            int tileIndex;

            if (inBuilding)
            {
                tileIndex = Random.Range(1, buildingPrefabs.Length);
                SpawnTile(tileIndex, inBuilding);
            }
            else
            {
                tileIndex = Random.Range(1, canyonPrefabs.Length);
                SpawnTile(tileIndex, inBuilding);
            }
           
            // Comprobar cambios de estado
            if(!inBuilding && tileIndex+1 == canyonPrefabs.Length)
            {
                inBuilding = true;
            } else if(inBuilding && tileIndex + 1 == buildingPrefabs.Length)
            {
                inBuilding = false;
            }

            // Eliminar tiles detrás del jugador
            DeleteTile();
        }
    }

    private void SpawnTile(int tileIndex, bool building)
    {
        GameObject newTile;

        if (building)
        {
            newTile = Instantiate(buildingPrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        } else
        {
            newTile = Instantiate(canyonPrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        }
        
        activeTiles.Add(newTile);

        // Rotación aleatoria (para dar más variedad)
        if (Random.Range(0, 2) > 0) {
            newTile.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (building && tileIndex + 1 == buildingPrefabs.Length)
        {
            newTile.transform.localScale = new Vector3(1, 1, -1);
        }

        zSpawn += tileLenght;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
