using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

   
    public GameBoard gameBoard;
    public GameObject mainCharacter;
    [SerializeField] private int currentTileIndex;


    void Start()
    {
        
    }


    public void SetCurrentTileIndex(int n)
    {
        List<Transform> nextTiles = new List<Transform>();

        for (int i = currentTileIndex + 1; i <= currentTileIndex + n; i++)
        {
            nextTiles.Add(gameBoard.tileTransforms[i]);
           
        }
      

        currentTileIndex += n;

        Vector3[] pathPoints = new Vector3[nextTiles.Count];
        for (int i = 0; i < nextTiles.Count; i++)
        {
            pathPoints[i] = nextTiles[i].position;
            pathPoints[i].y = 0.4f;
        }

        mainCharacter.transform.DOPath(pathPoints, 1f, PathType.Linear)
                 .SetEase(Ease.Linear);
                 

    }


    


    public void SetMainCharacter(GameObject c)
    {
        mainCharacter = c;
    }
}
