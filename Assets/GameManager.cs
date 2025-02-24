using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI diceNumberText;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void UpdateTheDiceText(int number)
    {
        diceNumberText.text = number.ToString();
    }
}
