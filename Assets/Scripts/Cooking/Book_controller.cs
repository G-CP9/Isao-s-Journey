using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] pages;
    public Minigame_manager manager;
    bool book_open = false;
    public GameObject book_pages;
    public Image image;
    public int num_page = 0;
    public AudioSource book;
    public Button next_button;
    public Button back_button;


    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = pages[num_page];
        if (num_page == 1)
        {
            next_button.gameObject.SetActive(false);
            back_button.gameObject.SetActive(true);
        }
        else if (num_page == 0)
        {
            next_button.gameObject.SetActive(true);
            back_button.gameObject.SetActive(false);
        }
    }


    public void Book_touch()
    {
        
        if (book_open == false)
        {
            book_pages.SetActive(true);
            manager.PauseGame();
            book_open = true;
            book.Play();
        }
        else
        {
            book.Play();
            book_pages.SetActive(false);
            manager.ResumeGame();
            book_open = false;
        }
        

    }

    public void Next()
    {
        if (num_page < 4)
        {
            num_page += 1;
            book.Play();

        }



    }

    public void Back()
    {
        if (num_page > 0)
        {
            num_page -= 1;
            book.Play();

        }


    }


}
