using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    public float speed = -3.0f;
    float objectWidth;
    void Start()
    {
        objectWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void Update()
    {
        if (!Endline.end)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        if (transform.position.x < -(Camera.main.orthographicSize * 2 * (16 / 9) + objectWidth / 2))
        {
            // transform.position += new Vector3(objectWidth*2, 0, 0);
            Destroy(gameObject);
        }
    }
}
