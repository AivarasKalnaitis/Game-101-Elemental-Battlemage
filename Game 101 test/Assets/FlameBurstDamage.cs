using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBurstDamage : MonoBehaviour
{
    public PlayerStats playerStats;
    ParticleSystem ps;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    private void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnParticleTrigger()
    {
        // get the particles which matched the trigger conditions this frame
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        playerStats.TakeDamage(numEnter/2);
    }
}
