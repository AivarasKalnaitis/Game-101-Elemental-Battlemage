using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoulder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 3)
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(10);
            Destroy(gameObject);
        }
    }

}
