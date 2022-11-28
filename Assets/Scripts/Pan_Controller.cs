using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan_Controller : MonoBehaviour
{
    // Start is called before the first frame update

    public bool onFire;
    public Food_controller food;
    public Grill_timer grill_Timer;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {

            food = collision.gameObject.GetComponent<Food_controller>();
            this.transform.SetParent(collision.transform);



        }
        if (collision.gameObject.tag == "Grill")
        {
            onFire = true;
            grill_Timer = collision.gameObject.GetComponent<Grill_timer>();
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (onFire)
        {
            grill_Timer.StartCooking = true;
            
        }


    }

    //La sartén no está en el fuego
    private void OnTriggerExit2D(Collider2D collision)
    {
        onFire= false;

        if (collision.gameObject.tag == "Food")
        {

            



        }
    }
}
