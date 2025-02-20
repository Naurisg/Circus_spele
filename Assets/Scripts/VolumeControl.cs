using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    private AudioSource audioSource;

    void Start()
    {
        // Assuming you have an AudioSource component on the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Set initial volume based on AudioManager settings
        volumeSlider.value = AudioListener.volume;

        // Add listener to detect changes in value
        volumeSlider.onValueChanged.AddListener(delegate { AdjustVolume(); });
    }

    public void AdjustVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}