using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeOverDistance : MonoBehaviour
{
    //public Transform transform;

    private ParticleSystem system;
    private ParticleSystem.Particle[] particles;

    void Start()
    {
        //      transform = GetComponent<Transform>();
        system = GetComponent<ParticleSystem>();  
    }

    private void Update()
    {
        particles = new ParticleSystem.Particle[system.particleCount];

        for(int i = 0; i < particles.Length; i++)
        {
            ParticleSystem.Particle particle = particles[i];

            float distance = Vector2.Distance(transform.position, particle.position);

            if(distance > 0.1f)
            {
                particle.remainingLifetime = -1;
            }
        }
    }
}
