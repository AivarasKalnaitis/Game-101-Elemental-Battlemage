using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeLotus : MonoBehaviour
{
    private AudioSource japaneseBruh;
    public GameObject SoundMaster;
    void Start()
    {
        japaneseBruh = SoundMaster.GetComponent<AudioSource>();

    }

    private void PlayJapaneseBruh()
    {
        japaneseBruh.Play();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            PlayJapaneseBruh();
            Destroy(gameObject);
        }
    }

}
