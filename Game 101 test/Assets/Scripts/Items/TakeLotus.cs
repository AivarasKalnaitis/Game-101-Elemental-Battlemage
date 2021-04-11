using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeLotus : MonoBehaviour
{
    public GameObject TextCanvas;
    private AudioSource japaneseBruh;
    public GameObject SoundMaster;
    private ParticleSystem explodeParticles;
    private ParticleSystem.EmissionModule em;

    void Start()
    {
        japaneseBruh = SoundMaster.GetComponent<AudioSource>();
        explodeParticles = GetComponentInParent<ParticleSystem>();
        em = explodeParticles.emission;
        em.enabled = false;
    }

    private void PlayJapaneseBruh()
    {
        japaneseBruh.Play();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            TextCanvas.GetComponent<LotusUI>().LotusPlus();
            PlayJapaneseBruh();
            em.enabled = true;
            explodeParticles.Play();
            Destroy(gameObject);
        }
    }
}
