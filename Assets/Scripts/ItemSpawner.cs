using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public float initialSpawnInterval = 3.0f; 
    public float spawnRadius = 5.0f;

    private Transform[] spawnPoints;
    private float currentSpawnInterval; 

    private void Start()
    {
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }

        currentSpawnInterval = initialSpawnInterval; 

        StartCoroutine(SpawnItems());
    }

    private IEnumerator SpawnItems()
    {
        while (true)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject randomItemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
            Vector2 randomPosition = (Vector2)randomSpawnPoint.position + Random.insideUnitCircle * spawnRadius;

            Instantiate(randomItemPrefab, randomPosition, Quaternion.identity);

            yield return new WaitForSeconds(currentSpawnInterval);

            if (currentSpawnInterval > 1.0f)
            {
                currentSpawnInterval -= 0.1f;
            }
        }
    }
}
