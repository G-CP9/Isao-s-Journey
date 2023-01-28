using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Pot_controller : MonoBehaviour
{
    public Sprite[] pot_states;

    public int estado;
    bool filled;
    bool onFire;
    public bool isCook;
    public Timer timer;
    int time;



    // Start is called before the first frame update
    void Start()
    {
        estado = 0;
        isCook = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (onFire && filled)
        {
            time = Mathf.FloorToInt(timer.timeValue);
            Debug.Log(time);

            if (time == 12)
            {
                estado = 3;
            }
            if (time == 5)
            {
                estado = 4;
                isCook= true;
            }
            if (time == 0)
            {
                estado = 5;
                isCook = false;

            }
        }
        Pot_render();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Colisiooon");
        if ((collision.gameObject.name == "Agua") && estado == 0)
        {
            StartCoroutine(Water_fill());
           // Destroy(collision.gameObject);
        }
        if ((collision.gameObject.name == "Arroz") && estado == 1)
        {
            estado = 2;
            //Destroy(collision.gameObject);
            filled = true;
        }
        if ((collision.gameObject.name == "Plat") && isCook)
        {
            estado = 0;
            filled = false;
            timer.timeValue = 15;
        }
        if ((collision.gameObject.name == "Basura") && estado == 5)
        {
            estado = 0;
            filled = false;
            timer.timeValue = 15;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag== "Grill")
        {
            if (filled)
            {
                onFire = true;
                timer.StartCooking = true;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Grill")
        {
            onFire = false;
            timer.StartCooking = false;
        }
    }

    public void Pot_render()
    {
        Sprite state = pot_states[estado];
        GetComponent<SpriteRenderer>().sprite = state;

    }

    public void Clear_out()
    {
        estado = 0;
        filled = false;
    }

    IEnumerator Water_fill()
    {
        

        yield return new WaitForSeconds(2);

        estado = 1;
       
        Invoke("Original_pos", 1.0f);
        
    }

    void Original_pos()
    {
        this.GetComponent<Object_Draggeable>().Added();
        this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

}
