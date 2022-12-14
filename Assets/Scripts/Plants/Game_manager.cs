using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour
{
    public ProgressBar progress;
    public TextBox_Controller textBox_Controller;
    public GameObject final_screen;
    public GameObject boton_salir;

    private void Start()
    {
        final_screen.SetActive(false);
        boton_salir.SetActive(false);

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
        final_screen.SetActive(true);
        boton_salir.SetActive(false);
    }
}
