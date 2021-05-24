using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallDamageToGolem : MonoBehaviour
{
    public EnemyStats enemyStats;
    public ParticleSystem ps;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    private void OnParticleTrigger()
    {

        // get the particles which matched the trigger conditions this frame
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, enter);
        Debug.Log(numEnter);

        enemyStats.TakeDamage(1);
    }
}
