using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game_manager : MonoBehaviour
{
    public ProgressBar progress;
    public TextBox_Controller textBox_Controller;
    public GameObject final_screen;
    public Button interact_button;
    public Player player;

    //in game controlls
    public GameObject joystick;
    public GameObject interact_button_object;
    public GameObject play_controls;
    public GameObject play_button;

    
    
     



    private void Start()
    {
        final_screen.SetActive(false);
        play_controls.SetActive(false);
        
        

    }
    private void Update()
    {
        if(progress.slider.value == 30)
        {
            FinishGame();
        }
    }

    public void Play()
    {
        play_controls.SetActive(true);
        play_button.SetActive(false);
        textBox_Controller.StartWindow.SetActive(false);
        textBox_Controller.ResumeGame();
        textBox_Controller.toolbar_object.SetActive(true);
        textBox_Controller.ProgressBar.SetActive(true);
        textBox_Controller.Inventory.SetActive(true);
        textBox_Controller.Book.SetActive(true);
    }

    void FinishGame()
    {
        //textBox_Controller.PauseGame();
        final_screen.SetActive(true);
    }

    public void Interact()
    {
        player.interact_pressed = true;
    }

    public void Open_Book()
    {
        if(player.book_open == true)
        {
            player.Book_opened(false);

        }
        else
        {
            player.Book_opened(true);
        }
    }
}
