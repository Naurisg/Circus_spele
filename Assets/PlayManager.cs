using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{

    public List<Transform> nextTiles;
    public GameObject mainCharacter;
    [SerializeField] private Transform[] tileTransforms;

    [SerializeField] private int currentTileIndex;
    
    public static PlayManager instance;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }


    public void SetCurrentTileIndex(int n)
    {
        for (int i = currentTileIndex+1; i <= currentTileIndex+n; i++)
        {
            nextTiles.Add(tileTransforms[i]);
        }
        currentTileIndex += n;

    }

    public void SetMainCharacter(GameObject c)
    {
        mainCharacter = c;
    }

  
}
