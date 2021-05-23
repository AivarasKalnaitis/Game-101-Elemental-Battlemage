using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaGroundDamage : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        other.GetComponent<PlayerStats>().TakeDamage(2);
    }
}
