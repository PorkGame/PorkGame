using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public string timerMinutes;
    public string timerSeconds;

    private float startTime;
    private float stopTime;
    private float timerTime;
    private bool isRunning = false;

    // Use this for initialization
    void Start()
    {
        TimerReset();
        TimerStart();
        GameVariables.score = 5000;
    }

    public void TimerStart()
    {
        if (!isRunning)
        {
            isRunning = true;
            startTime = Time.time;
        }
    }

    public void TimerStop()
    {
        if (isRunning)
        {
            isRunning = false;
            stopTime = timerTime;
        }
    }

    public void TimerReset()
    {
        stopTime = 0;
        isRunning = false;
        timerMinutes = timerSeconds = "00";
    }

    public void Scoring()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timerTime = stopTime + (Time.time - startTime);
        int minutesInt = (int)timerTime / 60;
        int secondsInt = (int)timerTime % 60;
        if (GameVariables.score > 0)
        {
            GameVariables.score = 5000 - (minutesInt * 100 + secondsInt);
        }
        else
        {
            GameVariables.score = 0;
        }

        if (isRunning)
        {
            timerMinutes = (minutesInt < 10) ? "0" + minutesInt : minutesInt.ToString();
            timerSeconds = (secondsInt < 10) ? "0" + secondsInt : secondsInt.ToString();
            this.GetComponent<Text>().text = timerMinutes + ":" + timerSeconds;
        }
    }
}
