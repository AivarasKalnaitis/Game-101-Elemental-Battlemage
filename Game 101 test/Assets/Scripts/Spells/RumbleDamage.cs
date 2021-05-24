using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleDamage : MonoBehaviour
{
    public ParticleSystem ps;
    public List<ParticleCollisionEvent> collisionEvents;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == 3)
        {
            int numCollisionEvents = ps.GetCollisionEvents(other, collisionEvents);

            int i = 0;

            while (i < numCollisionEvents)
            {
                if (other.layer == 3)
                {
                    other.GetComponent<PlayerStats>().TakeDamage(2);
                    i++;
                }
            }
        }
    }
}
