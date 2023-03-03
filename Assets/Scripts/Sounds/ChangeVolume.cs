using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer soundMixer;
    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup soundsMixerGroup;
    
    public Slider volumeSlider;

    
    public void ChangeVolumeSounds()
    {
        musicMixerGroup.audioMixer.SetFloat( "MyExposedParam", volumeSlider.value);
        soundsMixerGroup.audioMixer.SetFloat("MyExposedParam", volumeSlider.value);
    }
    
}
