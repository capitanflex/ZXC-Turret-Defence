using System;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] music;
    [SerializeField] private AudioMixerGroup _masterMixer;
    [SerializeField] private AudioMixerGroup _soundsMixer;
    
 
    
    public void PlaySound(string SoundName)
    {
        
        var audioSource = gameObject.AddComponent<AudioSource>();
        var sound = GetSoundByName(SoundName);
        audioSource.clip = sound.clip;
        switch (sound.mixerGroupType)
        {
            case MixerGroupType.Master:
                audioSource.outputAudioMixerGroup = _masterMixer;
                break;
            case MixerGroupType.Sounds:
                audioSource.outputAudioMixerGroup = _soundsMixer;
                break;
            
        }
        
        
        audioSource.Play();
    }
    

    private Sound GetSoundByName(string SoundName)
    {

        foreach (var sound in sounds)
        {
            if (sound._name == SoundName)
            {
                return sound;
            }
        }
       

        throw new Exception("noSound");
    }
    
}