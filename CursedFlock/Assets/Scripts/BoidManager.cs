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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnBoid();
        }
    }

    public Vector3 GetNextWaypoint(Vector3 currentWaypointPosition)
    {
        for (int i=0; i<waypointList.Count; i++)
        {
            if (waypointList[i].transform.position == currentWaypointPosition)
            {
                if (i + 1 < waypointList.Count)
                    return waypointList[i].transform.position;
                else
                    return waypointList[0].transform.position;
            }
        }
        return Vector3.zero;
    }

    void SpawnBoid()
    {
        Boid boidInstance = Instantiate(BoidPrefab, BoidSpawnPoint.position, Quaternion.identity).GetComponent<Boid>();
        activeBoidList.Add(boidInstance);
        boidInstance.parentManager = this;
    }
}
