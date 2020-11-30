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

    void Start()
    {
        velocity = (Random.rotation * transform.forward).normalized * initialSpeed;
        nextWaypointIndex = 0;
    }

    void Update()
    {
        foreach (BoidBehaviour behaviour in parentManager.ActiveBoidBehaviours)
        {
            velocity += behaviour.GetBehaviourForce(this, parentManager.activeBoidList, parentManager.threatList, parentManager.foodList, parentManager.waypointList[nextWaypointIndex].transform.position) * behaviour.weight * Time.deltaTime;
        }

        transform.position += Vector3.ClampMagnitude(velocity, maxSpeed) * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * rotationSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Wall")
        {
            //transform.position += other.gameObject.transform.position - transform.position;
            velocity *= -1;
            //velocity = (other.gameObject.transform.position - transform.position).normalized * initialSpeed;
        }

        if (other.tag == "Waypoint" && parentManager.waypointList[nextWaypointIndex] == other.gameObject)
        {
            Debug.Log("hit waypoint " + nextWaypointIndex);
            nextWaypointIndex++;
            if (nextWaypointIndex >= parentManager.waypointList.Count)
                nextWaypointIndex = 0;

            Debug.Log("next waypoint:  " + nextWaypointIndex);
        }
    }
}
