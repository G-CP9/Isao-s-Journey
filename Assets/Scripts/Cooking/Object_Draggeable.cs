using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Draggeable : MonoBehaviour
{
    Vector2 difference = Vector2.zero;
    Collider2D object_collider;
    public Vector2 originalPos;
    List<string> pan_ingredients = new List<string>();
    List<string> pot_ingredients = new List<string>();

    Pot_controller pot_Controller;
    



    private void Start()
    {
        pan_ingredients.Add("Cebolla");
        pan_ingredients.Add("Zanahoria");
        pan_ingredients.Add("Curry");
        pan_ingredients.Add("Patata");
        pan_ingredients.Add("Pollo");

        pot_ingredients.Add("Arroz");

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
        if(this.gameObject.name == "Pot" && !pot_ingredients.Contains(collision.gameObject.name) && collision.gameObject.name != "Agua")
        {
            collision.gameObject.transform.position = collision.gameObject.GetComponent<Food_draggable>().originalPos;
        }
        if(this.gameObject.name == "Pot" && collision.gameObject.name == "Pan")
        {
            this.gameObject.transform.position = originalPos;
        }
        if (collision.gameObject.name == "Plat")
        {
                        
            if(this.gameObject.name == "Pot")
            {
                Pot_controller pot = this.gameObject.GetComponent<Pot_controller>();
                this.gameObject.transform.position = originalPos;

            }
            if (this.gameObject.name == "Pan")
            {
                Pan pan = this.gameObject.GetComponent<Pan>();
                this.gameObject.transform.position = originalPos;

            }

        }
        
        if(this.gameObject.name == "Pan" && !pan_ingredients.Contains(collision.gameObject.name))
        {
            collision.gameObject.transform.position = collision.gameObject.GetComponent<Food_draggable>().originalPos;

        }

        if (this.gameObject.name == "Pot")
        {
            Pot_controller pot = this.gameObject.GetComponent<Pot_controller>();
            if (collision.gameObject.name == "Agua")
            {
                object_collider.enabled = !object_collider.enabled;
            }
        }
            


    }

    public void Added()
    {
        this.gameObject.transform.position = originalPos;
        
    }
}   
    
