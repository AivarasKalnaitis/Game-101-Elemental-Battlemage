using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public float fireRate;

    void Update()
    {
        if (speed != 0)
            transform.position += transform.forward * (speed * Time.deltaTime);
        else
            Debug.Log("No speed");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = 0;

        Destroy(gameObject);
    }
}
