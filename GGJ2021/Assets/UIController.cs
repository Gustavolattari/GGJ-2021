using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text score;

    PlayerController controller;

    private void Awake()
    {
        controller = FindObjectOfType<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetScore();
    }

    void GetScore()
    {
        score.text = "Score: " + controller.score;
    }

    
}
