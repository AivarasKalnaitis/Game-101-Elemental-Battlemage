using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_PlanetaryDevastation : MonoBehaviour
{
    private Vector3 sizing;
    private Vector3 singularSizing;

    public float suckedRocks;
    public bool stopSucking;
    public SuckingInwards suckedParticlesScript;

    void Awake()
    {
        transform.localScale = Vector3.one * 0.1f;
        singularSizing = new Vector3(0.000002f, 0.000002f, 0.000002f);

    }

    // Update is called once per frame
    void Update()
    {
        suckedRocks = suckedParticlesScript.destroyedCount;

        if (transform.localScale.x < 1)
        {
            if(suckedRocks > 0)
            {
                transform.localScale += singularSizing * ((suckedRocks * 100) / suckedRocks / GetComponent<CircleCollider2D>().radius);
            }
            else
            {
                transform.localScale += singularSizing * (suckedRocks / GetComponent<CircleCollider2D>().radius);
            }
        }
        else
        {
            //transform.localScale = new Vector3(1f, 1f, 1f);
            Invoke("StopSucking", 3f);
        }
    }

    void StopSucking()
    {
        stopSucking = true;
    }
}
