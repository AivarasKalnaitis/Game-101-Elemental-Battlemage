using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ice_Spikes_Damage : MonoBehaviour
{

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(20);
            Debug.Log("-20");
        }
    }
}
