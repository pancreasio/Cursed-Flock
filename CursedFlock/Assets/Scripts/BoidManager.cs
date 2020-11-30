using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    public GameObject BoidPrefab;
    public Transform BoidSpawnPoint;
    public List<Boid> activeBoidList;

    public List<BoidBehaviour> ActiveBoidBehaviours;
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

    void SpawnBoid()
    {
        activeBoidList.Add(Instantiate(BoidPrefab, BoidSpawnPoint.position, Quaternion.identity).GetComponent<Boid>());
    }
}
