using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Pan_controller : MonoBehaviour
{
    public Sprite[] pan_states;


    int estado;
    bool filled;
    bool onFire;
    public bool isCook;
    public Timer timer;

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
            isCook = false;
            int time = Mathf.FloorToInt(timer.timeValue);
            Debug.Log(time);

            if (time == 12)
            {
                estado = 6;
            }
            if (time == 5)
            {
                estado = 7;
                isCook = true;
            }
            if (time == 0 )
            {
                estado = 8;
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

        }
        if ((collision.gameObject.name == "Curry") && estado == 4)
        {
            estado = 5;
            Destroy(collision.gameObject);
            filled = true;

        }

        if ((collision.gameObject.name == "Plat") && isCook)
        {
            estado = 0;
            filled = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Grill")
        {

            if(filled)
            {
                onFire = true;
                timer.StartCooking = true;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Grill")
        {
            onFire = false;
            timer.StartCooking = false;
        }
    }

    public void Pan_render()
    {
        Sprite state = pan_states[estado];
        GetComponent<SpriteRenderer>().sprite = state;

    }

    public void Clear_out()
    {
        estado = 0;
        filled = false;
    }


   

}
