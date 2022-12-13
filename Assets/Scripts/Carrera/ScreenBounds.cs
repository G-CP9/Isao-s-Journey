using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    Vector2 screenBounds;
    float objectWidth, objectHeight;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.y;
    }

    
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        // Sumar/restar el ancho y alto del objeto depende de la posición del pivot
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth/2, screenBounds.x - objectWidth/2);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y + objectHeight);
        transform.position = viewPos;
    }
}
