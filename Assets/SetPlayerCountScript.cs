using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetPlayerCountScript : MonoBehaviour
{

    public int _playerCount = 2;
    [SerializeField] private TextMeshProUGUI playerCountText;

    [SerializeField] private ChooseCharacterScript characterScript;

    private void Start()
    {
        playerCountText.text = _playerCount.ToString();
    }

    public void IncreasePlayerCount()
    {
        if (_playerCount<7)
        {
            _playerCount++;
            characterScript.playerCount = _playerCount;
            playerCountText.text = _playerCount.ToString();
            
        }

       
    }


    public void DecreasePlayerCount()
    {
        if (_playerCount>2)
        {
            _playerCount--;
            characterScript.playerCount = _playerCount;
            playerCountText.text = _playerCount.ToString();
            
        }

    }

  
        
}
