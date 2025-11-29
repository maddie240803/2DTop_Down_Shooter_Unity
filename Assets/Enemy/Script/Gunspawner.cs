using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunspawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] objectsToSpawn; 
    public float spawnInterval = 10f;    

    [Header("Spawn Area Limits")]
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObjectAtRandomPos();
            timer = 0f;
        }
    }

    void SpawnObjectAtRandomPos()
    {
       
        if (objectsToSpawn.Length == 0) return;

       
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector2 spawnPosition = new Vector2(randomX, randomY);

       
        int randomIndex = Random.Range(0, objectsToSpawn.Length);

        
        if (objectsToSpawn[randomIndex] == null) return;

        
        Instantiate(objectsToSpawn[randomIndex], spawnPosition, Quaternion.identity);
    }
}
