using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{

    public float speed;

    public GameObject button;

    // Start is called before the first frame update
    private void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 1)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else
        {
            button.SetActive(true); 
        }
    }
}
