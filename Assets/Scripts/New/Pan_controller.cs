using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Pan_controller : MonoBehaviour
{
    public Sprite[] pan_states;

    int estado;
    bool filled;
    bool onFire;
    public Grill_timer grill_Timer;

    // Start is called before the first frame update
    void Start()
    {
        estado= 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(onFire && filled) 
        {
            int time = Mathf.FloorToInt(grill_Timer.timeValue);
            Debug.Log(time);

            if (time == 29)
            {
                estado = 5;
            }
            if (time == 5)
            {
                estado = 6;
            }
            if (time == 0 )
            {
                estado = 7;
            }
        }
        Pan_render();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Colisiooon");
        if ((collision.gameObject.name == "Patata") && estado == 0)
        {
            estado = 1;
            Destroy(collision.gameObject);
        }
        if ((collision.gameObject.name == "Zanahoria") && estado == 1)
        {
            estado = 2;
            Destroy(collision.gameObject);

        }
        if ((collision.gameObject.name == "Cebolla") && estado == 2)
        {
            estado = 3;
            Destroy(collision.gameObject);

        }
        if ((collision.gameObject.name == "Pollo") && estado == 3)
        {
            estado = 4;
            Destroy(collision.gameObject);
            filled = true;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Grill")
        {
            onFire = true;
            grill_Timer.StartCooking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Grill")
        {
            onFire = false;
            grill_Timer.StartCooking = true;
        }
    }

    public void Pan_render()
    {
        Sprite state = pan_states[estado];
        GetComponent<SpriteRenderer>().sprite = state;

    }

    public void Cook()
    {
        
    }

}
