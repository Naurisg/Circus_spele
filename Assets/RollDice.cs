using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class RollDice : MonoBehaviour
{

    [SerializeField] private Vector3 startPos;

    [SerializeField] private Vector3[] diceRotations;
    [SerializeField] private bool isRolliing;

    public int diceNumber;

    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpDuration;
    [SerializeField] private PlayerMovement playerMovement;

  

    void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRolliing)
        {
            Roll();
        }
    }


    public void Roll()
    {
        isRolliing = true;
        diceNumber = Random.Range(1, 7);

        Vector3 jumpPos = new Vector3(startPos.x ,startPos.y,startPos.z);

        transform.DOJump(jumpPos, jumpPower, 1, jumpDuration).SetEase(Ease.Linear);
        transform.DORotate(diceRotations[diceNumber - 1], jumpDuration).OnComplete(() =>
        {
            startPos = transform.position;
            isRolliing = false;
            GameManager.instance.UpdateTheDiceText(diceNumber);
            PlayManager.instance.MoveCurrentPlayer(diceNumber);
            //PlayManager.instance.SetCurrentTileIndex(diceNumber);
            //playerMovement.SetCurrentTileIndex(diceNumber);


        });
    }
}
