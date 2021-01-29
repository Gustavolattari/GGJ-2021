using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [HideInInspector]
    public int remainingTime;

    [SerializeField]
    private int totalTime;

    private void Start()
    {

        remainingTime = totalTime;
        StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine("CountDown");
    }

    public void StopTimer()
    {
        StopCoroutine("CountDown");
    }

    public string ConvertTime(float seconds)
    {
        string timeString;
        //var ts = System.TimeSpan.FromSeconds(seconds);
        //timeString = $"{ts.Minutes}:{ts.TotalSeconds}";

        timeString = string.Format("{0:0}:{1:00}", Mathf.Floor(seconds / 60), seconds % 60);

        return timeString;
    }

    IEnumerator CountDown()
    {
        while (remainingTime > 0 && !GameManager.instance.isGameOver)
        {
            yield return new WaitForSeconds(1);
            remainingTime--;
            if (remainingTime <= 0)
            {
                GameManager.instance.GameOver();
                StopTimer();
            }
            Debug.Log(ConvertTime(remainingTime));
        }
    }
}
