using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] screams;

    private int ScreamIndex;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            
            
        }

        foreach (Sound s in screams)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.clip = s.clip;
            
        }
    }

    void Start()
    {
        Play("Crickets");
    }

    public void PlayScreamNoise() 
    {
        //Debug.Log("Scream");
        if (ScreamIndex == screams.Length)
        {
            ScreamIndex = 0;
        }
        screams[ScreamIndex].source.Play() ;
        ScreamIndex++;
    }

    public void Play (string name)
    {
        if(name == "Scream")
        {
            PlayScreamNoise();
        }
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        if (s.source.isPlaying && !s.PlayOverItself)
        {
            return;
        }
        else
        {
            s.source.Play();
        }
    }
}
