using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsScript : MonoBehaviour
{
    public AudioClip[] soundEffects;
    public AudioSource audioSource;

    public Slider volumeSlider;


    private void Start()
    {
        // Set initial volume based on AudioManager settings
        volumeSlider.value = audioSource.volume;

        // Add listener to detect changes in value
        volumeSlider.onValueChanged.AddListener(delegate { AdjustVolume(); });
    }

    public void AdjustVolume()
    {
        audioSource.volume = volumeSlider.value;
    }

    public void Hover()
    {
        audioSource.PlayOneShot(soundEffects[0]);
    }

    public void Clicked()
    {
        audioSource.PlayOneShot(soundEffects[1]);
    }

    public void OnDice()
    {
        audioSource.loop = true;
        audioSource.clip = soundEffects[2];
        audioSource.Play();
    }
}
