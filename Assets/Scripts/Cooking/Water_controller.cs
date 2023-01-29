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
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Pot")
        {
            pot.estado = 1;
            pot_gameobject.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;


        }
    }*/ 
    IEnumerator Water_fill()
    {


        yield return new WaitForSeconds(2);

        pot.estado = 1;

        Invoke("Original_pos", 1.0f);

    }

    void Original_pos()
    {
        
        pot_gameobject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
