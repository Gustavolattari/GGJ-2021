using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText, timeText, endScoreText;
    [SerializeField]
    private GameObject endGameInfo;

    List<GameObject> hidingPlaces;
    List<GameObject> usedHidingPlaces;

    private void Awake()
    {
        hidingPlaces = new List<GameObject>();
        usedHidingPlaces = new List<GameObject>();
        HidingPlace[] arr = GameObject.FindObjectsOfType<HidingPlace>();
        for (int i = 0; i < arr.Length; i++)
        {
            hidingPlaces.Add(arr[i].gameObject);
        }

        endGameInfo = GameObject.Find("End_Game_Info").gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0"; 
        
        
        endGameInfo.SetActive(false);
        Debug.Log(endGameInfo);
    }

    public GameObject GetHidingPlace()
    {
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

    public void ToggleEndGameInfo()
    {
        endGameInfo.SetActive(!endGameInfo.activeSelf);
    }
}
