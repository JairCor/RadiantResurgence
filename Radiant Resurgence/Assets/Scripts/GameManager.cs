using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Wave Info")]
    private int currentWave = 1;
    private int totalMutantsKilled = 0;
    [SerializeField] private int mutantsPerWave = 0;
    private int mutantsKilledThisRound = 0;
    
    [Header("Game Objects")]
    [SerializeField] private MutantSpawner mutantSpawner;
    [SerializeField] private TextMeshProUGUI killCounterText;
    [SerializeField] private TextMeshProUGUI waveCounterText;

    void Start()
    {
        StartNextWave();
    }

    void StartNextWave()
    {
        Debug.Log("Wave " + currentWave + " started!");
        mutantsPerWave += 2; // Increasing mutants for each wave completed 
        SpawnMutants(mutantsPerWave);
        mutantsKilledThisRound = 0;
    }

    //Controls how many mutants are spawned per wave
    void SpawnMutants(int count)
    {
        for (int i = 0; i < count; i++)
        {
            StartCoroutine(WaitTime());
            mutantSpawner.SpawnWalker();
        }
    }

    
    // Logging info/stats and starting the next wave if player killed all the mutants
    public void OnMutantDeath()
    {
        totalMutantsKilled++;
        killCounterText.text = totalMutantsKilled.ToString();
        mutantsKilledThisRound++;
        Debug.Log("Mutant killed! Total killed: " + totalMutantsKilled);

        if (mutantsKilledThisRound >= mutantsPerWave){
            currentWave++;
            waveCounterText.text = currentWave.ToString();
            StartNextWave();
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5f);
    }
}
