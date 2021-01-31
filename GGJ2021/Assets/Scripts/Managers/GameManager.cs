using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int highScore;

    LevelManager levelManager;
    Timer time;
    PlayerController playerController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
        void Start() 
    { 
        time = GameObject.Find("Level Manager").GetComponent<Timer>();
        if (time == null)
            Debug.LogError("The Game_Manager did not find the Timer!");

        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        if (levelManager == null)
            Debug.LogError("The Game_Manager did not find the Level Manager!");

        playerController = GameObject.Find("Gary").GetComponent<PlayerController>();
    }

    public void ChangeLevel (int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ChangeLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void RestartScene()
    {
        Debug.Log("Restart");
        Scene scene = SceneManager.GetActiveScene();
        levelManager = null;
        SceneManager.LoadScene(scene.name);
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        time.StartTimer();
    }

    public void GameOver()
    {
        levelManager.ToggleEndGameInfo();
        if (playerController.score > highScore)
            highScore = playerController.score;
        levelManager.UpdateEndLevelScores($"Score: {playerController.score}\n"  + $"High Score: {highScore}");
    }
}
