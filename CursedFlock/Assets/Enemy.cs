using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float constantSpeed;

    void Update()
    {
        transform.Translate(transform.forward* constantSpeed* Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bird")
        {
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Wall")
        {
            transform.position = other.bounds.center - transform.position;
        }
    }
}
