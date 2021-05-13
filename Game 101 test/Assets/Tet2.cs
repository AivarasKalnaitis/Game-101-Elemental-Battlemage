using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tet2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"Tet other collider: {other.gameObject.layer}");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("LEL");
    }
}
