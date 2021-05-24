using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceVortex : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f);
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(10);
        }
    }
}
