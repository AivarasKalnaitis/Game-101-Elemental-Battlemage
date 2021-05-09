using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource japanese_bruh;
    public AudioSource Slime_Death;
    
    public List<AudioSource> GameSoundtracks;
    //private Dictionary<string, AudioSource> AudioSources;
    // Start is called before the first frame update
    void Start()
    {
        GameSound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string soundPlayed)
    {
        //japanese_bruh.Play();
        Slime_Death.Play();

    }

    private void GameSound()
    {
        Debug.Log("KEKx");
        int randomSong = Random.Range(0, GameSoundtracks.Count);
        Debug.Log(randomSong);
        GameSoundtracks[randomSong].Play();
        Invoke("GameSound", GameSoundtracks[randomSong].clip.length);
    }
}
