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
    public ParticleSystem ps;

    public bool isDestroyed = false;

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        transform.localScale = Vector3.one * 0.1f;
        singularSizing = new Vector3(0.000010f, 0.000010f, 0.0000010f);
        var em = ps.emission;
        em.enabled = false;
    }

    void Update()
    {
        suckedRocks = suckedParticlesScript.destroyedCount;

        if (transform.localScale.x < 2)
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
            Invoke("StopSucking", 1.5f);
            Invoke("Explode", 3f);   
        }
    }

    void StopSucking()
    {
        stopSucking = true;
    }

    void Explode()
    {
        var em = ps.emission;
        em.enabled = true;

        Invoke("EnlargeCollider", 0.55f);
        Invoke("DisableMesh", 0.55f);
        Invoke("DissableCollider", 1.2f);

        Destroy(gameObject, 4f);
        isDestroyed = true;
    }

    void EnlargeCollider()
    {
        GetComponent<CircleCollider2D>().radius = 5f;
    }

    void DisableMesh()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void DissableCollider()
    {
        GetComponent<Collider2D>().enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(30);
        }

        else if(collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<EnemyStats>().TakeDamage(30);
        }
    }
}
