using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Rumble_Ground : MonoBehaviour
{
    public ParticleSystem eruption;
    public GameObject crackObject;

    private void Awake()
    {
        eruption.Stop();
    }

    private void Start()
    {
        Invoke("Erupt", 5f);
    }

    public void Erupt()
    {
        eruption.Play();

        List<ParticleSystem.Particle> particles = new List<ParticleSystem.Particle>();

        Destroy(crackObject, 1f);
        Destroy(gameObject, 3f);
    }
}
