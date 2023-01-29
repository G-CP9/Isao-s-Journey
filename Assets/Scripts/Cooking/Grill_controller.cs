using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Grill_controller : MonoBehaviour
{
    public bool isEmpty;
    public GameObject objeto;
    Pot_controller pot;
    Pan pan;

    // Start is called before the first frame update
    void Start()
    {
        isEmpty = true;
        GetComponent<SpriteRenderer>().enabled= false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        objeto = collision.gameObject;

        if(collision.gameObject.name == "Pot")
        {
            pot = collision.GetComponent<Pot_controller>();

            if(pot.filled == true)
            {
                isEmpty = false;
                GetComponent<SpriteRenderer>().enabled = true;
            }

        }

        if (collision.gameObject.name == "Pan")
        {
            pan = collision.GetComponent<Pan>();

            if (pan.filled == true)
            {
                isEmpty = false;
                GetComponent<SpriteRenderer>().enabled = true;
            }

        }



    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isEmpty = true;
        GetComponent<SpriteRenderer>().enabled = false;

    }
}
