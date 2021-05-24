using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(5);
        }
    }
}
