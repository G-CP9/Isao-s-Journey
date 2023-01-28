using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Food_controller : MonoBehaviour
{
    Vector2 difference = Vector2.zero;
    Collider2D object_collider;
    Vector2 originalPos;

    Pot_controller pot_Controller;

    // Start is called before the first frame update
    private void Start()
    {
        object_collider = GetComponent<Collider2D>();
        originalPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    /* void Food_added()
    {
        this.gameObject.SetActive(false);
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Pan")
        {
            if ((this.gameObject.name == "Patata") && collision.gameObject.GetComponent<Pan>().estado == 0)
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(Adding());
            }
            if ((this.gameObject.name == "Zanahoria") && collision.gameObject.GetComponent<Pan>().estado == 1)
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(Adding());

            }
            if ((this.gameObject.name == "Cebolla") && collision.gameObject.GetComponent<Pan>().estado == 3)
            {
                Debug.Log("A");
                this.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(Adding());

            }
            if ((this.gameObject.name == "Curry") && collision.gameObject.GetComponent<Pan>().estado == 4)
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(Adding());

            }
            if ((this.gameObject.name == "Pollo") && collision.gameObject.GetComponent<Pan>().estado == 5)
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(Adding());
            }


        }
        if (collision.gameObject.name == "Pot")
        {
            Debug.Log("A");
            if ((this.gameObject.name == "Agua") && collision.gameObject.GetComponent<Pot_controller>().estado == 0)
            {
                
                pot_Controller = collision.gameObject.GetComponent<Pot_controller>();
                Invoke("Fill", 2.0f);
            }

            if ((this.gameObject.name == "Arroz") && collision.gameObject.GetComponent<Pot_controller>().estado == 1)
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(Adding());
            }

        }

        

    }

    IEnumerator Adding()
    {
        this.GetComponent<Object_Draggeable>().Added();
      
        yield return new WaitForSeconds(2);

        
        this.GetComponent<SpriteRenderer>().enabled = true;
    }

    void Fill()
    {
        Debug.Log("Aaaa");
        pot_Controller.estado = 1;
        this.GetComponent<Object_Draggeable>().Added();
        
    }

}
