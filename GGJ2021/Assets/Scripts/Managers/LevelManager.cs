using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText, timeText, endScoreText;
    [SerializeField]
    private GameObject endGameInfo;
    public bool EndOnce;
    public GameObject DangUI;
    private DN_InGameUI DangUIScript;
    List<GameObject> hidingPlaces;
    List<GameObject> usedHidingPlaces;
    public List<GameObject> animals;
    Timer timer;

    [SerializeField]
    Text creatureAmount;

    PlayerController playerController;

    private void Awake()
    {
        Time.timeScale = 1f;
        hidingPlaces = new List<GameObject>();
        usedHidingPlaces = new List<GameObject>();
        animals = new List<GameObject>();
        HidingPlace[] arr = GameObject.FindObjectsOfType<HidingPlace>();
        for (int i = 0; i < arr.Length; i++)
        {
            hidingPlaces.Add(arr[i].gameObject);
        }

        AnimalAI[] animalArr = FindObjectsOfType<AnimalAI>();
        for (int i = 0; i < animalArr.Length; i++)
        {
            animals.Add(animalArr[i].gameObject);
        }
        endGameInfo = GameObject.Find("End_Game_Info").gameObject;
        endGameInfo.SetActive(false);
        playerController = FindObjectOfType<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        scoreText.text = "Score: 0";
        DangUIScript = DangUI.GetComponent<DN_InGameUI>();
        timer = FindObjectOfType<Timer>();
        endGameInfo.SetActive(false);
        Debug.Log(endGameInfo);
    }

    private void Update()
    {
        creatureAmount.text = "Animals Remaining: " + animals.Count;
    }

    public GameObject GetHidingPlace()
    {
        if (hidingPlaces.Count == 0)
        {
            hidingPlaces = usedHidingPlaces;
            usedHidingPlaces = new List<GameObject>();
        }
        int rand = Random.Range(0, hidingPlaces.Count - 1);//returns a random hiding place in the list
        GameObject reference = hidingPlaces[rand];
        usedHidingPlaces.Add(reference);
        hidingPlaces.RemoveAt(rand);
        return reference;
    }//returns a random hiding place

    public void UpdateTime(string _time)
    {
        timeText.text = _time;
    }

    public void UpdateScore(string _score)
    {
        scoreText.text = _score;
    }

    public void UpdateEndLevelScores(string text)
    {
        endScoreText.text = text;
    }

    public void ToggleEndGameInfo(bool active)
    {
        endGameInfo.SetActive(active);
    }

    public void RestartScene()
    {
        Debug.Log("Restart");
        Scene scene = SceneManager.GetActiveScene();
        //levelManager = null;
        SceneManager.LoadScene(scene.name);
        // = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        timer.StartTimer();
    }

    public void GameOver()
    {
        if (EndOnce == false)
        {
            DangUIScript.Endgame();
            EndOnce = true;
        }
        
        ToggleEndGameInfo(true);
        Time.timeScale = 0;
        playerController.score += timer.remainingTime * 100;
        if (playerController.score > GameManager.instance.GetScore())
            GameManager.instance.SetScore(playerController.score);
        UpdateEndLevelScores($"Score: {playerController.score}\n" + $"High Score: {GameManager.instance.GetScore()}");
    }

    public void ChangeLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
