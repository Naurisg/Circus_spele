using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolotionManager : MonoBehaviour
{

    public TMP_Dropdown dropdown; // Inspector üzerinden baðla

    void Start()
    {
        dropdown.onValueChanged.AddListener(OptionSelected);
    }

    void OptionSelected(int index)
    {
        Debug.Log("Seçilen indeks: " + index);

        switch (index)
        {
            case 0:
                Screen.SetResolution(1920,1080, Screen.fullScreen);
               
                break;
            case 1:
                Screen.SetResolution(1366, 768, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
        }
    }
}
