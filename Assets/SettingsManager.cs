using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{

    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    [SerializeField] private int resolotionDropdownIndex;

    [SerializeField] private TMP_Dropdown resolotionDropdown;

    public AudioSource sfxAudioSource;

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
}
