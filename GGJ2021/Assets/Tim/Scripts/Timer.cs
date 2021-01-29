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
        var ts = System.TimeSpan.FromSeconds(seconds);
        timeString = $"{ts.Minutes}:{ts.Seconds}";

        return timeString;
    }

    IEnumerator CountDown()
    {
        while (remainingTime > 0)
        {
            if(remainingTime <= 0)
            {
                GameManager.instance.GameOver();
                StopTimer();
            }
            yield return new WaitForSeconds(1);
            remainingTime--;

            ConvertTime(remainingTime);
        }
    }
}
