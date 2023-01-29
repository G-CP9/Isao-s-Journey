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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Book_touch()
    {
        if(book_open == false)
        {
            book_pages.SetActive(true);
            manager.PauseGame();
            book_open = true;
        }
        else
        {
            book_pages.SetActive(false);
            manager.ResumeGame();
            book_open = false;
        }
        
    }

    
}
