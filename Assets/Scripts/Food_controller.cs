using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Food_controller : MonoBehaviour
{
    public Sprite[] food_states;
    
    public Grill_Controller grill;


    public void Start()
    {
        

    }

    private void Update()
    {
      

    }

    public void Cook(int index)
    {
       
        Sprite state = food_states[index];
        GetComponent<SpriteRenderer>().sprite = state;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         
        if(collision.gameObject.tag == "Basura")
        {
            Destroy(this.gameObject);

        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pan")
        {
            collision.transform.SetParent(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pan")
        {
            collision.transform.SetParent(collision.transform,false);
        }
    }


}
