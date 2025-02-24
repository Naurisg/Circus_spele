using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public bool isPaused;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;

    public static MenuManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;    
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseResumeButton();
        }
    }

    public void PauseResumeButton()
    {
        isPaused = !isPaused;

        Time.timeScale = isPaused ? 0 : 1;
        pausePanel.SetActive(isPaused ? true : false);
    }

    public void LeaderboardButton()
    {

    }

    public void SettingsButton()
    {

    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenue");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
