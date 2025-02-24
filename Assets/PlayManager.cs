using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayManager : MonoBehaviour
{

    public int maxPlayerIndex;
    public int currentPlayerIndex;

    [SerializeField] private int setChracterIndex;

    public GameBoard gameBoard;
    
    [SerializeField] private int currentTileIndex;

    public PlayerMovement[] playerMovements;

   

    public static PlayManager instance;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        
    }

    public void SetMaxPlayerIndex(int n)
    {
        maxPlayerIndex = n;
    }

    public void MoveCurrentPlayer(int n)
    {
        playerMovements[currentPlayerIndex].SetCurrentTileIndex(n);

        if (currentPlayerIndex == 0) GameManager.instance.IncreaseRollDiceCount();

        currentPlayerIndex++;

        if (currentPlayerIndex >= maxPlayerIndex)
        {
            currentPlayerIndex = 0;
        }

    }
       

    public void SetCharacter(GameObject g)
    {
        playerMovements[setChracterIndex].gameObject.SetActive(true);
        playerMovements[setChracterIndex].SetCharacter(g);
        setChracterIndex++;
    }





}
