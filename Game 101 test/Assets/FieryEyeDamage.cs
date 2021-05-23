using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieryEyeDamage : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if(other.layer == 3)
        {
            other.GetComponent<PlayerStats>().TakeDamage(10);
        }
    }
}
