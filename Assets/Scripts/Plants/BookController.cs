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
    public Button next_button;
    public Button back_button;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = pages[num_page];
        if (num_page == 4)
        {
            next_button.gameObject.SetActive(false);
            back_button.gameObject.SetActive(true);
        }
        else if(num_page == 0) 
        {
            next_button.gameObject.SetActive(true);
            back_button.gameObject.SetActive(false);
        }
        else
        {
            next_button.gameObject.SetActive(true);
            back_button.gameObject.SetActive(true);
        }
    }

    public void Next()
    {
        if(num_page < 4)
        {
            num_page += 1;
            book.Play();

        }
        
        

    }

    public void Back()
    {
        if(num_page > 0)
        {
            num_page -= 1;
            book.Play();

        }
       

    }

     
}
