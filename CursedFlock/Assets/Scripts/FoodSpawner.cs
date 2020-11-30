using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    private BoxCollider spawnerBounds;
    public GameObject foodPrefab;
    public float timeToSpawn;

    public List<GameObject> spawnedFoodList;

    public delegate void FoodAction(GameObject foodInstance);
    private float spawnTimer;

    void Start()
    {
        spawnTimer = timeToSpawn;
        Food.OnDestroyed = OnFoodDestroyed;
        spawnerBounds = GetComponent<BoxCollider>();
        spawnedFoodList = new List<GameObject>();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            spawnedFoodList.Add(Instantiate(foodPrefab, new Vector3(Random.Range(spawnerBounds.bounds.min.x, spawnerBounds.bounds.max.x),
                spawnerBounds.transform.position.y, Random.Range(spawnerBounds.bounds.min.z, spawnerBounds.bounds.max.z)), Random.rotation));
            spawnTimer = timeToSpawn;
        }
    }

    void OnFoodDestroyed(GameObject food)
    {
        if(spawnedFoodList.Contains(food))
            spawnedFoodList.Remove(food);
    }
}
