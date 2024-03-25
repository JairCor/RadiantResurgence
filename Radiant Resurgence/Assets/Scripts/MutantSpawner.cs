using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantSpawner : MonoBehaviour
{
    [SerializeField] private GameObject mutantPrefab; // Prefab of the walker enemy
    [SerializeField] private float spawnInterval = 3f; // Time interval between spawns
    [SerializeField] private float spawnXRange = 7f;
    [SerializeField] private float spawnYRange = 2f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnWalker();
            timer = 0f; // Reset the timer
        }
    }

    void SpawnWalker()
    {
        // Randomly generate a position outside of the map boundaries
        Vector3 spawnPosition = GetRandomSpawnPosition();
        // Instantiate a walker at the spawn position
        GameObject newWalker = Instantiate(mutantPrefab, spawnPosition, Quaternion.identity);
    }


    Vector3 GetRandomSpawnPosition()
    {
        // Generate random x and y coordinates within the spawn area
        float spawnX = Random.Range(-spawnXRange, spawnXRange);
        float spawnY = Random.Range(-spawnYRange, spawnYRange);
        if(spawnY > 0){
            spawnY += 2*spawnYRange;
            return new Vector3(spawnX, spawnY, transform.position.z);
        }
        else{
            spawnY += 2*spawnYRange;
            return new Vector3(spawnX, -spawnY, transform.position.z);
        }
    }
    
}
