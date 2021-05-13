using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_PlanetaryDevastation : MonoBehaviour
{
    private Vector3 sizing;
    private Vector3 singularSizing;
    void Awake()
    {
        transform.localScale = Vector3.zero;
        singularSizing = new Vector3(0.002f, 0.002f, 0.002f);

    }
    void Start()
    {
        sizing = Vector3.Lerp(Vector3.zero, new Vector3(1f, 1f, 1f), 0.06f);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 1)
        {
            transform.localScale += singularSizing;
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        gameObject.GetComponent<CircleCollider2D>().radius = transform.localScale.x * 2;
        //transform.localScale = sizing;
    }


    void FixedUpdate()
    {

        
    }
}
