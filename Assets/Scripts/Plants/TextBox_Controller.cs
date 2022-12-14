using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextBox_Controller : MonoBehaviour
{
    public Player player;
    public BoxController box;
    public BinController bin;
    public ToolBarController toolBar;

    //Text Box Grande
    public Text text_box1;

    public string box_text;
    public string bin_text;
    public string planta;
    string flower_picked;

    //Text Box Acciones
    public Text text_box2;
    string flower_collision;

    //Start game
    public GameObject StartWindow;


    List<string> Flower_types = new List<string>()
    {
        "Lavanda",
        "Camomila",
        "Calendula"
    };


    private void Start()
    {
        text_box1.text = "";
        text_box2.text = "";
    }

    private void Update()
    {
        flower_collision = player.flower;
        Debug.Log(flower_collision);
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartWindow.SetActive(false);
            ResumeGame();

        }
        else if (box.box_open)
        {
            Box_Text();
        }
        else if (bin.bin_open)
        {
            Bin_Text();
        }

        else if(Flower_types.Contains(flower_collision) )
        {
            Flower(flower_collision);
        }

        else if(player.picked)
        {
            Flower_pick(flower_collision);
        }

        else if(toolBar.num_objects == 10)
        {
            text_box2.text = "Inventario lleno, guarda o tira alguna flor";
        }

        else
        {
            Clear_Text();
        }

        Debug.Log(player.picked);

    }

    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(1);

        player.picked = false;
        Debug.Log("a");


        // Code to execute after the delay
    }

    public void Box_Text()
    {
        text_box1.text = box_text;   
    }

    public void Bin_Text()
    {
        text_box1.text = bin_text;

    }

    public void Clear_Text()
    {
        text_box1.text = "";
        text_box2.text = "";

    }

    public void Flower(string flower)
    {
        text_box2.text = "¿Quieres coger una " + flower + "?";
        flower_picked = flower;
        
    }

    public void Flower_pick(string flower)
    {
        text_box2.text = "Has cogido una " + flower_picked;
        StartCoroutine(ExecuteAfterTime());
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
