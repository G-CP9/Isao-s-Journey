using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Water_controller : MonoBehaviour
{
    Pot_controller pot;
    GameObject pot_gameobject;
    Animator animator;
    public Sprite[] pot_states;
    int estado;

    //Sounds

    public AudioSource filling;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Pot")
        {
            pot = collision.gameObject.GetComponent<Pot_controller>();
            pot_gameobject = collision.gameObject;


            pot_gameobject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.transform.position = collision.gameObject.GetComponent<Object_Draggeable>().originalPos;

            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            animator.SetTrigger("filling");
            
            
            

        }
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Pot")
        {
           
            pot.GetComponent<Object_Draggeable>().Added();
            pot.gameObject.GetComponent<CircleCollider2D>().enabled = true;

        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            pot.estado = 1;
            pot_gameobject.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Pot")
        {
            pot.estado = 1;
            pot_gameobject.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;


        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Pot")
        {
            //Detectamos la olla y sus componentes
            pot = collision.gameObject.GetComponent<Pot_controller>();
            pot_gameobject = collision.gameObject;

            if(pot.estado == 0)
            {
                pot_gameobject.SetActive(false);
                pot_gameobject.transform.position = pot_gameobject.GetComponent<Object_Draggeable>().originalPos;
                animator.SetTrigger("filling");
                filling.Play();
                estado = 1;
                Render();
                Invoke("Pot_filled", 1.340179f);
            }

            
        }
    }

    private void Pot_filled()
    {
        pot.estado = 1;
        estado = 0;
        Render();
        pot_gameobject.SetActive(true);
        

    }
    IEnumerator Water_fill()
    {


        yield return new WaitForSeconds(2);

        pot.estado = 1;

        Invoke("Original_pos", 1.0f);

    }

    

    public void Render()
    {
        Sprite state = pot_states[estado];
        GetComponent<SpriteRenderer>().sprite = state;

    }
}
