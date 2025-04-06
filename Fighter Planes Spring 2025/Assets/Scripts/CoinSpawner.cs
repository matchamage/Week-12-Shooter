using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 2f;
    public float disappearDelay = 3f;
    public Vector2 spawnAreaMin = new Vector2(-8f, -4f); // Adjust as needed
    public Vector2 spawnAreaMax = new Vector2(8f, 4f);  // Adjust as needed

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0f;
        }
    }

    void SpawnCoin()
    {
        if (coinPrefab != null)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                0f // Assuming 2D
            );

            GameObject spawnedCoin = Instantiate(coinPrefab, randomPosition, Quaternion.identity);
            Destroy(spawnedCoin, disappearDelay); // Destroy after a delay
        }
        else
        {
            Debug.LogError("Coin Prefab not assigned in the Inspector!");
        }
    }
}
