using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class RandomBGmusic : MonoBehaviour
{
    private int currentTrack;
    private int newRandomTrack;
    private SoundManager soundManager;
    [SerializeField] private AudioSource audioSource;
    public Sound[] music;
    [SerializeField] private AudioMixerGroup _musicMixer;


    void Start()
    {
        currentTrack = Random.Range(0, music.Length-1);
        
        PlaySound(currentTrack.ToString());
        
    }
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            newRandomTrack = Random.Range(0, music.Length-1);
            while (currentTrack == newRandomTrack)
            {
                newRandomTrack = Random.Range(0, music.Length-1);
            }
            if (currentTrack!= newRandomTrack)
            {
                currentTrack = newRandomTrack;
                PlaySound(currentTrack.ToString());
            }
        }
    }
    public void PlaySound(string SoundName)
    {
        print(SoundName);
        
        var sound = GetSoundByName(SoundName);
        audioSource.clip = sound.clip;
        audioSource.outputAudioMixerGroup = _musicMixer;
        audioSource.Play();
    }
    

    private Sound GetSoundByName(string SoundName)
    {
        
        foreach (var sound in music)
        {
            if (sound._name == SoundName)
            {
                return sound;
            }
        }

        throw new Exception("noSound");
    }

    
}


