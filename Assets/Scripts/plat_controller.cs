using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class plat_controller : MonoBehaviour
{
    public Sprite[] plat_states;


    int estado;
    bool onFire;
    public bool complete;

    
    
    public Pan_controller pan_Controller;
    public Pot_controller pot_Controller;

    // Start is called before the first frame update
    void Start()
    {
        estado = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Plat_render();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Colisiooon");
        if (collision.gameObject.name == "Pot")
        {
            pot_Controller = collision.gameObject.GetComponent<Pot_controller>();
            if (pot_Controller.isCook)
            {
                if(estado == 0)
                {
                    estado = 1;
                }
                if(estado == 2)
                {
                    estado = 3;
                    complete = true;
                }
            }
        }
        if (collision.gameObject.name == "Pan")
        {
            pan_Controller = collision.gameObject.GetComponent<Pan_controller>();

            if (pan_Controller.isCook)
            {
                if (estado == 0)
                {
                    estado = 2;
                }
                if (estado == 1)
                {
                    estado = 3;
                    complete = true;

                }
            }
        }

    }

   

    public void Plat_render()
    {
        Sprite state = plat_states[estado];
        GetComponent<SpriteRenderer>().sprite = state;

    }
}
