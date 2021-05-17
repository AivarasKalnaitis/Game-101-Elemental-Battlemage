using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Rumble_Ground : MonoBehaviour
{
    public ParticleSystem eruption;
    public GameObject crackObject;

    private void Awake()
    {
        var em = eruption.emission;
        em.enabled = false;
    }

    private void Start()
    {
        Invoke("Erupt", 10f);
    }

    public void Erupt()
    {
        var em = eruption.emission;
        em.enabled = true;
        eruption.Play();

        List<ParticleSystem.Particle> particles = new List<ParticleSystem.Particle>();



        Destroy(crackObject, 1f);
        Destroy(gameObject, 3f);
    }
}
