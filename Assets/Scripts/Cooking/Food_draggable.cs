using System.Collections.Generic;
using UnityEngine;

public class Food_draggable : MonoBehaviour
{
    Vector2 difference = Vector2.zero;
    Collider2D object_collider;
    public Vector2 originalPos;
    List<string> pan_ingredients = new List<string>();
    List<string> pot_ingredients = new List<string>();

    Pot_controller pot_Controller;




    private void Start()
    {
       

        object_collider = GetComponent<Collider2D>();
        originalPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        object_collider.enabled = !object_collider.enabled;
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }

    private void OnMouseUp()
    {

        object_collider.enabled = !object_collider.enabled;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        /*if (collision.gameObject.name != "Grill")
        {
            if (((this.gameObject.name == "Pot") && !pot_ingredients.Contains(collision.gameObject.name)))
            {
                if (collision.gameObject.name == "Arroz")
                    this.gameObject.transform.position = originalPos;

            }
            if (this.gameObject.name == "Pan" && !pan_ingredients.Contains(collision.gameObject.name))
            {
                this.gameObject.transform.position = originalPos;
            }
            else if (((collision.gameObject.name == "Pot") && (this.gameObject.name == "Agua")) || (collision.gameObject.name == "Agua") && (this.gameObject.name == "Pot"))
            {
                object_collider.enabled = !object_collider.enabled;

            }


        }*/

        if(collision.gameObject.name =="Pot")
        {
            Pot_controller pot = collision.gameObject.GetComponent<Pot_controller>();
            if(this.gameObject.name == "Arroz" &&  pot.estado != 1 )
            {
                this.gameObject.transform.position = originalPos;
            }
            if (this.gameObject.name == "Agua" && pot.estado == 0)
            {
                object_collider.enabled = !object_collider.enabled;
            }
            if (this.gameObject.name == "Agua" && pot.estado != 0)
            {
                this.gameObject.transform.position = originalPos;
            }

        }

        if (collision.gameObject.name == "Pan")
        {
            Pan pan = collision.gameObject.GetComponent<Pan>();
            if (this.gameObject.name == "Patata" && pan.estado != 0)
            {
                this.gameObject.transform.position = originalPos;
            }
            if (this.gameObject.name == "Zanahoria" && pan.estado != 1)
            {
                this.gameObject.transform.position = originalPos;
            }
            if (this.gameObject.name == "Cebolla" && pan.estado != 2)
            {
                this.gameObject.transform.position = originalPos;
            }
            if (this.gameObject.name == "Curry" && pan.estado != 3)
            {
                this.gameObject.transform.position = originalPos;
            }
            if (this.gameObject.name == "Pollo" && pan.estado != 4)
            {
                this.gameObject.transform.position = originalPos;
            }

        }


    }

    public void Added()
    {
        this.gameObject.transform.position = originalPos;

    }
}

