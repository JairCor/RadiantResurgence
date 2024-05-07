using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MutantSpawner mutantSpawner;
    [SerializeField] private TextMeshProUGUI killCounterText;
    [SerializeField] private TextMeshProUGUI waveCounterText;
    private int currentWave = 1;
    private int totalMutantsKilled = 0;
    private int mutantsPerWave = 0;
    private int mutantsKilledThisRound = 0;

    void Start()
    {
        StartNextWave();
    }

    void StartNextWave()
    {
        Debug.Log("Wave " + currentWave + " started!");
        mutantsPerWave += 2; // Increase mutants per wave for each new wave
        SpawnMutants(mutantsPerWave);
        mutantsKilledThisRound = 0;
    }

    void SpawnMutants(int count)
    {
        for (int i = 0; i < count; i++)
        {
            StartCoroutine(WaitTime());
            mutantSpawner.SpawnWalker();
        }
    }

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
