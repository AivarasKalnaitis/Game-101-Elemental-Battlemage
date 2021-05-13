using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexSpellScript : MonoBehaviour
{
    private List<bool> TossObject;
    public ParticleSystem ps;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    [SerializeField] private float pushForce;
    private IEnumerator coroutine;
    // Use this for initialization
    void Start()
    {
//        ps = GetComponent<ParticleSystem>();
        
    }

//    void OnParticleTrigger()
//    {
//        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
//
//        for (int i = 0; i < numEnter; i++)
//        {
//            ParticleSystem.Particle p = enter[i];
//            
//            enter[i] = p;
//        }
//
//        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
//        }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == 9)
        {
            //other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 1000 * Time.deltaTime;
            other.gameObject.GetComponent<EnemyMovement>().AffectedByVortex = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<EnemyMovement>().AffectedByVortex = false;
    }
}



