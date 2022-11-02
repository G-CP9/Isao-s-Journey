using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBarController : MonoBehaviour
{
    //Toolbar set up
    public Text Blue_flowers;
    int num_blue;
    public GameObject Icon_B; //icono de la flor azul

    public Text Pink_flowers;
    int num_pink;
    public GameObject Icon_P; //icono de la flor azul


    private void Start()
    {
        //Ocultamos Botones
        Icon_B.SetActive(false);
        Icon_P.SetActive(false);
    }




    public void UpdateScore(string item)
    {
        if (item == "Blue")
        {
            //Debug.Log("Ha entrado, guarra");
            num_blue += 1;
            //Debug.Log(num_blue);
            Blue_flowers.text = "x" + num_blue.ToString();

            if (num_blue == 1)
            {
                Icon_B.SetActive(true);
            }
        }
        if (item == "Pink")
        {
            num_pink++;
            Pink_flowers.text = "x" + num_pink.ToString();

            if (num_pink == 1)
            {
                Icon_P.SetActive(true);
            }

        }

    }
}
