using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantSpawner : MonoBehaviour
{
    [SerializeField] private GameObject mutantPrefab;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float spawnXRange = 7f;
    [SerializeField] private float spawnYRange = 2f;
    private GameObject newWalker;

    void Update()
    {
    }

    public void SpawnWalker()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        newWalker = Instantiate(mutantPrefab, spawnPosition, Quaternion.identity);
        newWalker.SetActive(true);
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
