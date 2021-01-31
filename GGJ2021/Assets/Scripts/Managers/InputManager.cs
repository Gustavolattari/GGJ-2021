using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerController playerController;
    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        if (playerController == null)
            Debug.LogError("The InputManager did not find the PLayerController!");

        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        if (levelManager == null)
            Debug.LogError("The InputManager did not find the LevelManager!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            CaptureAnimal();
    }

    void CaptureAnimal()
    {
        if(playerController.animalCount > 0)
        {
            int random = Random.Range(0, playerController.animalCount - 1);
            levelManager.animals.Remove(playerController.animals[random]);
            playerController.RemoveAnimal(random);
            levelManager.UpdateScore($"Score: {playerController.score}");
            if (levelManager.animals.Count == 0)
                levelManager.GameOver();
            playerController.GrabSound();

        }
    }
}
