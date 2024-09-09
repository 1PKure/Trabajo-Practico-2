using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPoolManager poolManager;
    [SerializeField] private float spawnInterval = 10f;

    void Start()
    {
        InvokeRepeating("SpawnPowerUp", spawnInterval, spawnInterval);
    }

    void SpawnPowerUp()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-10, 8f), Random.Range(-4f, 4f)); // Ajusta el rango de spawn
        poolManager.SpawnPowerUp(spawnPosition);
    }
}
