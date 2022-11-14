using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    //Vinculamos la caja
    public BoxController box;
    public BinController bin;


    //Texto Para escoger flor a guardar
    public GameObject FlorGuardar;
    public GameObject FlorTirar;

    //Start game
    public GameObject StartWindow;


    void Start()
    {
        box = FindObjectOfType<BoxController>();
        bin = FindObjectOfType<BinController>();
        PauseGame();


    }





    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            StartWindow.SetActive(false);
            ResumeGame();

        }
        if(box.box_open)
        {
            FlorGuardar.SetActive(true);

        }
        if(bin.bin_open)
        {
            FlorTirar.SetActive(true);
        }
        if(box.box_open == false)
        {
            FlorGuardar.SetActive(false);
        }
        if(bin.bin_open == false)
        {
            FlorTirar.SetActive(false);
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }


}
