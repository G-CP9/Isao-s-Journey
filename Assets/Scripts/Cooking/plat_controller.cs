using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class plat_controller : MonoBehaviour
{
    public Sprite[] plat_states;


    public int estado;
    bool onFire;
    

    int num_plats;

    public AudioClip bell;
    public AudioClip fill;
    AudioSource plat_sound;

    
    
    public Pan pan;
    public Pot_controller pot_Controller;

    // Start is called before the first frame update
    void Start()
    {
        plat_sound= GetComponent<AudioSource>();
        estado = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Plat_render();
        if(num_plats > 2)
        {
            SwapScene();
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Colisiooon");
        
        

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Pot")
        {
            pot_Controller = collision.gameObject.GetComponent<Pot_controller>();

            if (pot_Controller.isCook)
            {
                pot_Controller.Clear_out();
                plat_sound.PlayOneShot(fill);

                if (estado == 0)
                {
                    estado = 1;
                }
                if (estado == 2)
                {
                    estado = 3;

                    Invoke("Plat_complete", 1.0f);

                }
            }
        }
        if (collision.gameObject.name == "Pan")
        {
            pan = collision.gameObject.GetComponent<Pan>();
            pan.estado = 0;
            if (pan.isCook)
            {
                plat_sound.PlayOneShot(fill);
                if (estado == 0)
                {
                    estado = 2;
                }
                if (estado == 1)
                {
                    estado = 3;

                    Invoke("Plat_complete", 1.0f);




                }
            }
        }
    }


    public void Plat_render()
    {
        Sprite state = plat_states[estado];
        GetComponent<SpriteRenderer>().sprite = state;

    }

    void SwapScene()
    {
        SceneManager.LoadScene("Opria2");
    }
    void Plat_complete()
    {

        plat_sound.PlayOneShot(bell);
        this.GetComponent<SpriteRenderer>().enabled = false;
        num_plats++;

        if(num_plats == 2)
        {
            Invoke("SwapScene", 1.0f);
        }
        else 
        {
            
            Invoke("Complete", 1.0f);
        }
        
        
    }

    void Complete()
    {
        
        estado = 0;
        this.GetComponent<SpriteRenderer>().enabled = true;
        


    }

    
}
