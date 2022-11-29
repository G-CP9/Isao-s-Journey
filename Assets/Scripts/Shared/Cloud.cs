using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed;
    private Vector3 screenBounds;
    private float spriteWidth;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        spriteWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        if (transform.position.x > screenBounds.x + spriteWidth / 2)
        {
            transform.position = new Vector3(-screenBounds.x - spriteWidth / 2, transform.position.y, transform.position.z);
        }
    }
}
