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
        if (food_Timer.isCooking == true)
        {
            int time = Mathf.FloorToInt(food_Timer.timeValue);
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
            Sprite state = food_states[index];
            GetComponent<SpriteRenderer>().sprite = state;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Plancha")
        {
            food_Timer.isCooking = true;
            
        }
        if(collision.gameObject.tag == "Basura")
        {
            Destroy(this.gameObject);

        }
    }
}
