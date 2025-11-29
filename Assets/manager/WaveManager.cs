using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    [Header("Configuration")]
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 3f;
    public GameObject Winpanel;

    [Header("UI Settings")]
    public TextMeshProUGUI waveStateText;

    private int currentWave = 0;
    private bool isWaveInProgress = false;

    void Start()
    {
        if (enemyPrefab == null || spawnPoints.Length == 0)
        {
            Debug.LogError("Error: Enemy Prefab or Spawn Points are missing!");
        }
    }

    void Update()
    {
        if (isWaveInProgress) return;

        int enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemiesAlive == 0)
        {
            StartCoroutine(StartNextWave());
        }
    }

    IEnumerator StartNextWave()
    {
        isWaveInProgress = true; 
        yield return new WaitForSeconds(timeBetweenWaves);

        currentWave++; 

        if (currentWave > 4)
        {
            Winpanel.SetActive(true);
            
            yield break;
        }

       
        if (waveStateText != null)
            waveStateText.text = "Wave " + currentWave + " Starting...";

        yield return new WaitForSeconds(2f); 

        if (waveStateText != null)
            waveStateText.text = "";

       
        int enemiesToSpawn = currentWave * 5;

       
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); 
        }

        
        isWaveInProgress = false;
    }

    void SpawnEnemy()
    {
       
        if (spawnPoints.Length == 0) return;

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform randomPoint = spawnPoints[randomIndex];
        Instantiate(enemyPrefab, randomPoint.position, Quaternion.identity);
    }
}