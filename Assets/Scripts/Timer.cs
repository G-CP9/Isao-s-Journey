using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timerText;
    public bool StartCooking;
    public float timeValue = 15;

    // Start is called before the first frame update
   
    private void Start()
    {
        StartCooking= false;
    }

    private void Update()
    {
        if(StartCooking)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            DisplayTime(timeValue);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

