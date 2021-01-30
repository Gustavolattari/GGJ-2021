using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    LevelManager levelManager;
    Timer time;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
            
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        time = GetComponent<Timer>();
        if (time == null)
            Debug.LogError("The Game_Manager did not find the Timer!");
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        if (levelManager == null)
            Debug.LogError("The Game_Manager did not find the Level Manager!");
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
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        time.StartTimer();
    }

    public void GameOver()
    {
        levelManager.ToggleLevelButtons();
    }
}
