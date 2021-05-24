using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckingInwards : MonoBehaviour
{
    ParticleSystem system;
    ParticleSystem.Particle []particles;

    public List<ParticleCollisionEvent> collisionEvents;
    public float destroyedCount;
    public Spell_PlanetaryDevastation centerRockScript;
    public float multiplier;

    void Start()
    {
        system = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void Update()
    {
        if (centerRockScript.isDestroyed != true)
        {
            var em = system.emission;

            if (centerRockScript.stopSucking)
            {
                em.enabled = false;
            }

            em.rateOverTime = 10 + centerRockScript.transform.localScale.x * 15;
        }
    }

    /*
    private void FixedUpdate()
    {
        int numParticlesAlive = system.GetParticles(particles);

        for(int i = 0; i < numParticlesAlive; i++)
        {
            if (particles[i].position == destroyPositionTransform.position)
                particles[i].remainingLifetime = -1f;
        }

        system.SetParticles(particles, numParticlesAlive);
    }
    */

    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = system.GetCollisionEvents(other, collisionEvents);

        int i = 0;

        while(i < numCollisionEvents)
        {
            destroyedCount++;
            i++;
        }
    }
}
