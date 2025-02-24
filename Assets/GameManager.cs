using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject[] endPanelTexts;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI finishTimerText;
    [SerializeField] private TextMeshProUGUI diceNumberText;
    [SerializeField] private float timer;
    [SerializeField] private float finishTime;

    public Transform lastTile;

    public int rollDiceCount;


    public bool isGameDone;
    public static GameManager instance;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timer = 0;
        timerText.text = timer.ToString("00000");

    }


    void Update()
    {
        if (isGameDone) return;
        timer = Time.time;
        timerText.text = timer.ToString("00000");


        if (Input.GetKeyDown(KeyCode.Y))
        {
            YouWon();
        }
    }

    public void UpdateTheDiceText(int number)
    {
        diceNumberText.text = number.ToString();
    }

    public void IncreaseRollDiceCount()
    {
        rollDiceCount++;
    }


    public void YouWon()
    {
        isGameDone = true;
        endPanel.SetActive(true);
        endPanelTexts[1].SetActive(false);
        endPanelTexts[0].SetActive(true);
        finishTime = timer;
        finishTimerText.text = finishTime.ToString("00000");
        LocalLeaderboard.Instance.AddScore(PlayerPrefs.GetString("PlayerName"),rollDiceCount);
        LocalLeaderboard.Instance.PrintLeaderboard();
    }



    public void YouLost()
    {
        isGameDone = true;
        endPanel.SetActive(true);
        endPanelTexts[0].SetActive(false);
        endPanelTexts[1].SetActive(true);
        finishTime = timer;
        finishTimerText.text = finishTime.ToString("00000");
    }

}
