using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public BoidManager parentManager;

    public Vector3 velocity;
    private int nextWaypointIndex;
    public float initialSpeed;
    public float maxSpeed;
    public float rotationSpeed;

    public int FoodToTransform;
    private int FoodCounter;

    void Start()
    {
        velocity = (Random.rotation * transform.forward).normalized * initialSpeed;
        nextWaypointIndex = 0;
        FoodCounter = 0;
    }

    void Update()
    {
        foreach (BoidBehaviour behaviour in parentManager.activeBoidBehaviours)
        {
            velocity += behaviour.GetBehaviourForce(this, parentManager.activeBoidList, parentManager.threatList, parentManager.foodList, parentManager.waypointList[nextWaypointIndex].transform.position) * behaviour.weight * Time.deltaTime;
        }

        transform.position += Vector3.ClampMagnitude(velocity, maxSpeed) * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * rotationSpeed);
    }

    void Transform()
    {
        parentManager.activeBoidList.Remove(this);
        parentManager.threatList.Add(Instantiate(parentManager.EnemyPrefab, transform.position, transform.rotation));
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Food")
        {
            FoodCounter++;
            if(FoodCounter >= FoodToTransform)
                Transform();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Wall")
        {
            transform.position = other.bounds.center - transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint" && parentManager.waypointList[nextWaypointIndex] == other.gameObject)
        {
            nextWaypointIndex++;
            if (nextWaypointIndex >= parentManager.waypointList.Count)
                nextWaypointIndex = 0;
        }
    }
}
