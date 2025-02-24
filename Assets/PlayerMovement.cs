using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

   
    public GameBoard gameBoard;
    public GameObject character;
    [SerializeField] private int currentTileIndex;


    public bool isBot;

    void Start()
    {
        
    }

    private void Update()
    {
        //if (GameManager.instance.isGameDone) return;

        //if (Vector2.Distance(character.transform.position, GameManager.instance.lastTile.position) < .1f)
        //{
        //    if (isBot)
        //    {
        //        GameManager.instance.YouLost();
        //    }
        //    else
        //    {
        //        GameManager.instance.YouWon();
        //    }
        //}
    }


    public void SetCurrentTileIndex(int n)
    {
        List<Transform> nextTiles = new List<Transform>();


        if(currentTileIndex+n < gameBoard.tileTransforms.Count)
        {
            for (int i = currentTileIndex + 1; i <= currentTileIndex + n; i++)
            {
                nextTiles.Add(gameBoard.tileTransforms[i]);

            }
        }
        else
        {
            for (int i = currentTileIndex + 1; i < gameBoard.tileTransforms.Count; i++)
            {
                nextTiles.Add(gameBoard.tileTransforms[i]);

            }
        }

      
      

        currentTileIndex += n;

        Vector3[] pathPoints = new Vector3[nextTiles.Count];
        for (int i = 0; i < nextTiles.Count; i++)
        {
            pathPoints[i] = nextTiles[i].position;
            pathPoints[i].y = 0.4f;
        }

        character.transform.DOPath(pathPoints, 1f, PathType.Linear)
                 .SetEase(Ease.Linear).OnComplete(() =>
                 {

                     if (Vector3.Distance(character.transform.position, GameManager.instance.lastTile.position) < 1f)
                     {
                         if (isBot)
                         {
                             GameManager.instance.YouLost();
                         }
                         else
                         {
                             GameManager.instance.YouWon();
                         }
                     }

                 });
                 

    }


    public void SetCharacter(GameObject c)
    {
        character = c;
    }
    


}
