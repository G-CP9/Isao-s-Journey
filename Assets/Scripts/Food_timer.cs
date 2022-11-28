using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Food_timer : MonoBehaviour
{
    public float timeValue = 30;
    public Text timerText;
    public bool isCooking;
    
    

    private void Start()
    {
        isCooking = false;
    }
    private void Update()
    {
        if(isCooking)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            DisplayTime(timeValue);
        }

        
        Debug.Log(isCooking);
    }

   

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay% 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        timerText.text = string.Format("{0:00}:{1:00}",minutes, seconds);
    }
}
