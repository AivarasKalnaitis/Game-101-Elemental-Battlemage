using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPlayerSpell : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        other.GetComponent<EnemyStats>().TakeDamage(2);
    }
}
