using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panels : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject pausedPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject playerHealthBarPanel;
    [SerializeField] GameObject scorePanel;
    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource gameOverMusic;

    bool isPaused;

    void Start()
    {
        isPaused = false;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        Paused();
    }

    private void Paused()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            isPaused = true;
            bgMusic.Pause();
            pausedPanel.SetActive(true);
            playerHealthBarPanel.SetActive(false);
            scorePanel.SetActive(false);
        }

        if(isPaused)
        {
            Time.timeScale = 0;
            player.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            player.SetActive(true);
        }
    }

    public void GameIsOver()
    {
        isPaused = true;
        bgMusic.Pause();
        gameOverMusic.Play();
        gameOverPanel.SetActive(true);
        playerHealthBarPanel.SetActive(false);
        scorePanel.SetActive(false);
    }

    public void Resume()
    {
        isPaused = false;
        bgMusic.UnPause();
        pausedPanel.SetActive(false);
        playerHealthBarPanel.SetActive(true);
        scorePanel.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}