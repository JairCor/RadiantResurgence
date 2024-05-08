using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject mutantPrefab;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float spawnXRange = 7f;
    [SerializeField] private float spawnYRange = 2f;
    private GameObject newWalker;

    public void SpawnWalker()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        newWalker = Instantiate(mutantPrefab, spawnPosition, Quaternion.identity);
        newWalker.SetActive(true); // Devestating bug fix, Original Walker prefab would die and crash the game because of state AI complications
        // Had to keep original walker prefab alive, by deactivating and then spawning mutants, then activating them. Weird workaround

    }

    //Spawning mutant on random position (top or bottom due to map orientation)
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
