using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 1)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}
