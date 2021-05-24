using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnowball : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 3)
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
