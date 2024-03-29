using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Pot_controller : MonoBehaviour
{
    public Sprite[] pot_states;

    public int estado;
    public bool filled;
    bool onFire;
    public bool isCook;
    public Timer timer;
    int time;


    //Sounds
    public AudioSource pot_sounds;
    public AudioSource pot_filling;
    public AudioSource help_sound;

    public AudioClip ready;
    public AudioClip burned;


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
                help_sound.PlayOneShot(ready);
            }
            if (time == 0)
            {
                estado = 5;
                isCook = false;
                help_sound.PlayOneShot(burned);

            }
        }
        Pot_render();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Colisiooon");
        if ((collision.gameObject.name == "Agua") && estado == 0)
        {
            //StartCoroutine(Water_fill());
           // Destroy(collision.gameObject);
        }
        if ((collision.gameObject.name == "Arroz") && estado == 1)
        {
            estado = 2;
            //Destroy(collision.gameObject);
            filled = true;
            pot_filling.Play();
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag== "Grill")
        {
            if (filled)
            {
                pot_sounds.Play();
                onFire = true;
                timer.StartCooking = true;
            }


        }
        if (collision.gameObject.name == "limits")
        {
            this.gameObject.transform.position = this.gameObject.GetComponent<Object_Draggeable>().originalPos;
        }
        if ((collision.gameObject.name == "Plat") && isCook)
        {
            plat_controller plat = collision.gameObject.GetComponent<plat_controller>();
            if (plat.estado == 2 || plat.estado == 0 || plat.estado == 3)
            {

                Clear_out();
                timer.timeValue = 15;

                this.gameObject.transform.position = this.GetComponent<Object_Draggeable>().originalPos;

            }

        }
        if ((collision.gameObject.name == "Basura") && estado == 5)
        {
            Clear_out();

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
        this.gameObject.transform.position = this.gameObject.GetComponent<Object_Draggeable>().originalPos;
        timer.timeValue = 15;
        Pot_render();

    }

    
    
    

}
