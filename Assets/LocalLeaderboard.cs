using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class LocalLeaderboard : MonoBehaviour
{

    public TextMeshProUGUI leaderboardText;

    private string filePath;
    private LeaderboardData leaderboard = new LeaderboardData();

    public static LocalLeaderboard Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        filePath = Application.persistentDataPath + "/leaderboard.json";
        LoadLeaderboard();
        UpdateUI(); 
    }

    
    public void AddScore(string playerName, int score)
    {
        leaderboard.scores.Add(new ScoreEntry { playerName = playerName, score = score });


        leaderboard.scores.Sort((a, b) => a.score.CompareTo(b.score));

        if (leaderboard.scores.Count > 10)
            leaderboard.scores.RemoveAt(10);

        SaveLeaderboard();
        UpdateUI();
    }

    
    private void SaveLeaderboard()
    {
        string json = JsonUtility.ToJson(leaderboard, true);
        File.WriteAllText(filePath, json);
    }

   
    private void LoadLeaderboard()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            leaderboard = JsonUtility.FromJson<LeaderboardData>(json);
        }
    }

    
    public void PrintLeaderboard()
    {
        foreach (var entry in leaderboard.scores)
        {
            Debug.Log(entry.playerName + ": " + entry.score);
        }
    }


    public void UpdateUI()
    {
        if (leaderboardText == null) return;

        leaderboardText.text = " Leaderboard \n";
        int rank = 1;

        foreach (var entry in leaderboard.scores)
        {
            leaderboardText.text += $"{rank}. {entry.playerName} - {entry.score}\n";
            rank++;
        }
    }

}
