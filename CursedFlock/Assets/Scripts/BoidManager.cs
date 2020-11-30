using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    public GameObject boidPrefab;
    public GameObject EnemyPrefab;

    public GameObject cageCenter;

    public Transform boidSpawnPoint;

    public int initialBoids;

    public List<Boid> activeBoidList;
    public List<BoidBehaviour> activeBoidBehaviours;
    public List<GameObject> threatList;
    public List<GameObject> foodList;
    public List<GameObject> waypointList;
    public FoodSpawner foodSpawner;

    void Start()
    {
        foodList = foodSpawner.spawnedFoodList;
        for (int i = 0; i < initialBoids; i++)
        {
            SpawnBoid();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnBoid();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnEnemy();
        }
    }

    void SpawnBoid()
    {
        Boid boidInstance = Instantiate(boidPrefab, boidSpawnPoint.position, Quaternion.identity).GetComponent<Boid>();
        activeBoidList.Add(boidInstance);
        boidInstance.parentManager = this;
    }

    void SpawnEnemy()
    {
        GameObject enemyInstance = Instantiate(EnemyPrefab, boidSpawnPoint.position, Random.rotation);
        threatList.Add(enemyInstance);
    }
}
