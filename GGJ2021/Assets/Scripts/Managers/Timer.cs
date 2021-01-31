using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [HideInInspector]
    public int remainingTime;

    public int totalTime;

    LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        if (levelManager == null)
            Debug.LogError("The Timer did not find the LevelManager!");

        StartTimer();
    }

    public void StartTimer()
    {
        remainingTime = totalTime;
        StartCoroutine("CountDown");
    }

    public void StopTimer()
    {
        StopCoroutine("CountDown");
    }

    public string ConvertTime(float seconds)
    {
        string timeString;

        timeString = string.Format("{0:0}:{1:00}", Mathf.Floor(seconds / 60), seconds % 60);

        return timeString;
    }

    IEnumerator CountDown()
    {
        while (remainingTime > 0 )
        {
            yield return new WaitForSeconds(1);
            remainingTime--;
            if (remainingTime <= 0)
            {
                levelManager.GameOver();
                StopTimer();
            }
            levelManager.UpdateTime($"Time: {ConvertTime(remainingTime)}");
        }
    }
}
