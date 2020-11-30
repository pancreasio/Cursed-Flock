using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    public GameObject BoidPrefab;
    public Transform BoidSpawnPoint;

    public List<Boid> activeBoidList;
    public List<BoidBehaviour> ActiveBoidBehaviours;
    public List<GameObject> threatList;
    public List<GameObject> foodList;
    public List<GameObject> waypointList;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnBoid();
        }
    }

    void SpawnBoid()
    {
        Boid boidInstance = Instantiate(BoidPrefab, BoidSpawnPoint.position, Quaternion.identity).GetComponent<Boid>();
        activeBoidList.Add(boidInstance);
        boidInstance.parentManager = this;
    }
}
