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


    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        Invoke("StopSpell", 5.5f);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == 9)
        {
            //other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 1000 * Time.deltaTime;
            other.gameObject.GetComponent<EnemyMovement>().AffectedByVortex = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            other.gameObject.GetComponent<EnemyAffliction>().vortexApplicable = true;
        }
    }

    void StopSpell()
    {
        var em = ps.emission;
        em.enabled = false;
        Destroy(gameObject, 2f);
    }

    void DestroyItself()
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<EnemyMovement>().AffectedByVortex = false;
    }
}



