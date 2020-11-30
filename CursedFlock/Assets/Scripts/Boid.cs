using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    private BoidManager parentManager;

    private Vector3 velocity;
    public float initialSpeed;
    public float maxSpeed;
    public float rotationSpeed;

    void Start()
    {
        velocity = (Random.rotation * transform.forward).normalized * initialSpeed;
    }

    void Update()
    {
        //foreach (BoidBehaviour behaviour in parentManager.ActiveBoidBehaviours)
        //{

        //}

        transform.position += Vector3.ClampMagnitude(velocity, maxSpeed) * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * rotationSpeed);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Wall")
        {
            velocity *= -1;
        }
    }
}
