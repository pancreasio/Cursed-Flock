using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static FoodSpawner.FoodAction OnDestroyed;
    void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Wall")
            Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bird")
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        if(OnDestroyed!=null)
            OnDestroyed.Invoke(this.gameObject);
    }
}
