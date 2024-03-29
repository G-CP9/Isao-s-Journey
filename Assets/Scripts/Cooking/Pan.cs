using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Pan: MonoBehaviour
{
    public Sprite[] pan_states;


    public int estado;
    public bool filled;
    bool onFire;
    public bool isCook;
    public Timer timer;
    int time;

    //Sounds
    public AudioSource pan_sounds;

    public AudioSource pan_filling;

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
                estado = 6;
            }
            if (time == 5)
            {
                estado = 7;
                isCook = true;
                help_sound.PlayOneShot(ready);
            }
            if (time == 0)
            {
                estado = 8;
                isCook = false;
                help_sound.PlayOneShot(burned);

            }
        }
        Pan_render();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        if ((collision.gameObject.name == "Patata") && estado == 0)
        {
            estado = 1;
            //Destroy(collision.gameObject);
            pan_filling.Play();
        }
        if ((collision.gameObject.name == "Zanahoria") && estado == 1)
        {
            estado = 2;
            pan_filling.Play();
            //Destroy(collision.gameObject);
        }
        if ((collision.gameObject.name == "Cebolla") && estado == 2)
        {
            estado = 3;
            pan_filling.Play();
            //Destroy(collision.gameObject);
        }
        if ((collision.gameObject.name == "Curry") && estado == 3)
        {
            estado = 4;
            pan_filling.Play();
            //Destroy(collision.gameObject);
        }
        if ((collision.gameObject.name == "Pollo") && estado == 4)
        {
            estado = 5;
            pan_filling.Play();
            //Destroy(collision.gameObject);
            filled = true;
        }

        

        

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Grill")
        {
           
            if (filled)
            {
                onFire = true;
                timer.StartCooking = true;
            }

        }
        if ((collision.gameObject.name == "Plat") && isCook)
        {
            plat_controller plat = collision.gameObject.GetComponent<plat_controller>();
            if (plat.estado == 1 || plat.estado == 0 || plat.estado == 3)
            {
                estado = 0;
                filled = false;
                timer.timeValue = 15;
            }
        }

        if ((collision.gameObject.name == "Basura") && estado == 8)
        {
            estado = 0;
            filled = false;
            timer.timeValue = 15;
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

    public void Pan_render()
    {
        Sprite state = pan_states[estado];
        GetComponent<SpriteRenderer>().sprite = state;

    }

    public void Clear_out()
    {
        estado = 0;
        filled = false;
        this.gameObject.transform.position = this.gameObject.GetComponent<Object_Draggeable>().originalPos;
        timer.timeValue = 15;
        Pan_render();

    }




}
