using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    public Sprite[] pages;
    public Image image;
    public int num_page = 0;
    public AudioSource book;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = pages[num_page];
    }

    public void Next()
    {
        if(num_page < 4)
        {
            num_page += 1;
        }
        
    }

    public void Back()
    {
        if(num_page > 0)
        {
            num_page -= 1;
        }
        
    }

     
}
