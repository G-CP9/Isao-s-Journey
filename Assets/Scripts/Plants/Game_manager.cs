using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour
{
    public ProgressBar progress;
    public TextBox_Controller textBox_Controller;

    private void Start()
    {
        
    }
    private void Update()
    {
        if(progress.slider.value == 30)
        {
            FinishGame();
        }
    }

    void FinishGame()
    {
        textBox_Controller.PauseGame();
    }
}
