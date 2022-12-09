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


        isEmpty = false;
        GetComponent<SpriteRenderer>().enabled = true;


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isEmpty = true;
        GetComponent<SpriteRenderer>().enabled = false;

    }
}
