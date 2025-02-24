using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetPlayerCountScript : MonoBehaviour
{

    public int playerCount = 2;
    [SerializeField] private TextMeshProUGUI playerCountText;


    private void Start()
    {
        playerCountText.text = playerCount.ToString();
    }

    public void IncreasePlayerCount()
    {
        if (playerCount<7)
        {
            playerCount++;
            playerCountText.text = playerCount.ToString();
        }

       
    }


    public void DecreasePlayerCount()
    {
        if (playerCount>2)
        {
            playerCount--;
            playerCountText.text = playerCount.ToString();
        }

        
    }
}
