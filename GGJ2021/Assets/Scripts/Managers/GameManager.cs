using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
            
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeLevel (int level)
    {
        SceneManager.LoadScene(level);
    }

    public void GameOver()
    {
        isGameOver = true;
        ChangeLevel(0);
    }
}
