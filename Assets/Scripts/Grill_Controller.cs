using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;

public class Grill_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timer_text;
    public Food_controller food;
    public Grill_timer grill_Timer;
    int index = 0;

    private void Update()
    {
        if (grill_Timer.StartCooking)
        {
            int time = Mathf.FloorToInt(grill_Timer.timeValue);
            Debug.Log(time);

            if (time == 30)
            {
                index = 0;
            }
            if (time == 5)
            {
                index = 1;
            }
            if (time == 0)
            {
                index = 2;
            }

            food.Cook(index);
        }
    }

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grill_Timer.StartCooking = false;
        food = null;


    }
}
