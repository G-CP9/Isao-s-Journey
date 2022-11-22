using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class food_sprite_changer : MonoBehaviour
{
    public Sprite[] food_states;
    public Food_timer food_Timer;
    int index;


    public void Start()
    {
        

    }

    private void Update()
    {
        
        Cook();

    }

    public void Cook()
    {
        int time = Mathf.FloorToInt(food_Timer.timeValue);
        Debug.Log(time);
        if(time == 60)
        {
            index = 0;
        }
        if(time == 50)
        {
            index = 1;
        }
        Sprite state = food_states[index];
        GetComponent<SpriteRenderer>().sprite = state;
    }
}
