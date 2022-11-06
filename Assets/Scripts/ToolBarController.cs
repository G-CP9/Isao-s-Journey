using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class ToolBarController : MonoBehaviour
{
    //Toolbar set up
    //Flower A
    public Text A_text;
    int num_A;
    public GameObject Icon_A; 

    //Flower B
    public Text B_text;
    int num_B;
    public GameObject Icon_B;

    //Flower C
    public Text C_text;
    int num_C;
    public GameObject Icon_C; //icono de la flor azul

    //Flower Poisoned
    public Text P_text;
    int num_poison;
    public GameObject Icon_P;

    //Vinculamos la ProgressBar
    public ProgressBar p_bar;

    //Score
    public Text Score;
    int score;


    private void Start()
    {
        //Ocultamos Botones
        Icon_A.SetActive(false);
        Icon_B.SetActive(false);
        Icon_P.SetActive(false);
        Icon_C.SetActive(false);


        //ProgressBar
        p_bar.SetInitProgress();
    }




    public void UpdateScore(string item)
    {
        if (item == "PlantA") 
        {
            num_A += 1;
            A_text.text = "x" + num_A.ToString();

            if (num_A == 1)
            {
                Icon_A.SetActive(true);
            }

            //Planta A = 1 punto
            //p_bar.IncrementProgress(0.01f);
            score++;

        }
        if (item == "PlantB")
        {
            num_B++;
            B_text.text = "x" + num_B.ToString();

            if (num_B == 1)
            {
                Icon_B.SetActive(true);
            }

            //Planta B = 3 puntos
            //p_bar.IncrementProgress(0.03f);
            score = score + 3;
        }
        if (item == "PlantC")
        {
            num_C++;
            C_text.text = "x" + num_C.ToString();

            if (num_C == 1)
            {
                Icon_C.SetActive(true);
            }

            //Planta C = 5 puntos
            //p_bar.IncrementProgress(0.05f);
            score = score + 5;
        }

        if (item == "Poison")
        {
            num_poison++;
            P_text.text = "x" + num_poison.ToString();

            if (num_poison == 1)
            {
                Icon_P.SetActive(true);
            }
            //Planta venenosa: -2 puntos
            //p_bar.DecreaseProgress(0.2f);

            score = score - 2;

        }
        
        p_bar.SetProgress(score);
        
    }
}
