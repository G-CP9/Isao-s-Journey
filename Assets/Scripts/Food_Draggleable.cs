using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Draggleable : MonoBehaviour
{
    Vector2 difference = Vector2.zero;
    Collider2D object_collider;
    Vector2 originalPos;

    public GameObject food_refill;


    private void Start()
    {
        object_collider = GetComponent<Collider2D>();
        originalPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    private void Update()
    {
        
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

    
}