using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float timeToSwapn;

    private float random;
    //private float totalTime;
    //private bool spawned = false;
    private GameObject obstacle;
    [SerializeField] private float spawnInterval = 2.0f;
    [SerializeField] private float minLifetime = 3.0f;
    [SerializeField] private float maxLifetime = 7.0f;
    [SerializeField] private float spawnXRange = 2.0f;
    [SerializeField] private float spawnYRange = 2.0f;

    private void Start()
    {
        //totalTime = 0;
        random = Random.Range(4, 6);
        InvokeRepeating("SpawnObstacle", spawnInterval, spawnInterval);
    }
    void SpawnObstacle()
    {

        Vector2 randomPosition = new Vector2(Random.Range(-spawnXRange, spawnXRange), Random.Range(-spawnYRange, spawnYRange));
        GameObject newObstacle = Instantiate(obstaclePrefab, randomPosition, Quaternion.identity);
        float lifetime = Random.Range(minLifetime, maxLifetime);
        Destroy(newObstacle, lifetime);
    }

    //private void Update()
    //{
    //    totalTime += Time.deltaTime;
    //    if (totalTime > timeToSwapn && !spawned)
    //    {
    //       obstacle = Instantiate(obstaclePrefab, new Vector2(0, random), Quaternion.identity);
    //       spawned = true;

    //    }
    //    else
    //    {
    //        Destroy(obstaclePrefab, Random.Range(3, 7));
    //    }


    //}


}
