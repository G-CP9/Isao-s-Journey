using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class ToolBarController : MonoBehaviour
{
    //Toolbar set up
    //Flower A
    public Text Lavanda_txt;
    public int num_Lavanda;
    public GameObject Icon_Lavanda; 

    //Flower B
    public Text Camomila_txt;
    public int num_Camomila;
    public GameObject Icon_Camomila;

    //Flower C
    public Text C_text;
   public int num_C;
    public GameObject Icon_C; //icon

    //Flower Poisoned 1
    public Text P_text;
    public int num_poison;
    public GameObject Icon_P;

    //Flower Poisoned 2
    public Text P2_text;
    public int num_poison2;
    public GameObject Icon_P2;

    //Flower Poisoned 3
    public Text P3_text;
    public int num_poison3;
    public GameObject Icon_P3;


    //ProgressBar
    public ProgressBar p_bar;

    //Score
    int score;

    //Capacity of the inventory
    public GameObject alert_capacity;
    public Text capacity;
    int max_capacity = 10;
    public int num_objects;

    //Bin
    //public BinController binController;

    private void Start()
    {
        //Hide the icons
        Icon_Lavanda.SetActive(false);
        Icon_Camomila.SetActive(false);
        Icon_C.SetActive(false);
        Icon_P.SetActive(false);
        Icon_P2.SetActive(false);
        Icon_P3.SetActive(false);


        //ProgressBar
        p_bar.SetInitProgress();
        num_objects = 0;
        alert_capacity.SetActive(false);
    }

    private void Update()
    {
        UpdateToolbar();
    }

    private void FixedUpdate()
    {
        UpdateToolbar();
    }

    public void UpdateToolbar()
    {
        //Lavandas A
        Lavanda_txt.text = "x" + num_Lavanda.ToString();
        if (num_Lavanda == 1)
        {
            Icon_Lavanda.SetActive(true);
        }
        if(num_Lavanda == 0)
        {
            Icon_Lavanda.SetActive(false);
        }


        //Lavandas B
        Camomila_txt.text = "x" + num_Camomila.ToString();

        if (num_Camomila == 1)
        {
            Icon_Camomila.SetActive(true);
        }
        if (num_Camomila == 0)
        {
            Icon_Camomila.SetActive(false);
        }

        //Lavandas C
        C_text.text = "x" + num_C.ToString();

        if (num_C == 1)
        {
            Icon_C.SetActive(true);
        }
        if(num_C == 0)
        {
            Icon_C.SetActive(false);
        }

        //Lavandas venenosas 1
        P_text.text = "x" + num_poison.ToString();

        if (num_poison == 1)
        {
            Icon_P.SetActive(true);
        }
        if (num_poison == 0)
        {
            Icon_P.SetActive(false);
        }

        //Lavandas venenosas 2
        P2_text.text = "x" + num_poison2.ToString();

        if (num_poison2 == 1)
        {
            Icon_P2.SetActive(true);
        }
        if (num_poison2 == 0)
        {
            Icon_P2.SetActive(false);
        }




        //Lavandas venenosas 3
        P3_text.text = "x" + num_poison3.ToString();

        if (num_poison3 == 1)
        {
            Icon_P3.SetActive(true);
        }
        if (num_poison3 == 0)
        {
            Icon_P3.SetActive(false);
        }


        if (num_objects == 10)
        {
          alert_capacity.SetActive(true);
        }
        else
        {
            alert_capacity.SetActive(false);

        }



        p_bar.SetProgress(score);
        capacity.text = num_objects + " / " + max_capacity;
    }

    public void PickFlower(string item, bool poison)
    {
        if (num_objects < max_capacity)
        {

            if (!poison)
            {
                if (item == "Lavanda")
                {
                    num_Lavanda ++;

                }
                if (item == "Camomila")
                {
                    num_Camomila++;

                }
                if (item == "PlantC")
                {
                    num_C++;
                    
                }
                

            }

            if(poison)
            {
                if (item == "Lavanda")
                {
                    //Lavanda venenosa tipo 1
                    num_poison++;
                    
                    
                }

                if (item == "Camomila")
                {
                    //Lavanda venenosa tipo 2
                    num_poison2++;
                    
                    

                }

                if (item == "PlantC")
                {
                    //Lavanda venenosa tipo 2
                    num_poison3++;
                    

                    

                }
                
            }


            num_objects++;
            
        }

        
        
        
    }

    public void KeepFlower(string flower)
    {
        if(flower == "Lavanda")
        {
            num_Lavanda--;
            //Lavanda A = 1 punto
            score++;
        }
        if(flower == "Camomila")
        {
            num_Camomila--;
            //Lavanda B = 3 puntos
            score = score + 3;
        }
        if(flower == "PlantC")
        {
            num_C--;
            //Lavanda C = 5 puntos
            score = score + 5;
        }
        if(flower == "Poison1")
        {
            num_poison--;
            //Lavanda venenosa 1 = -1 puntos
            score = score - 1;
            Debug.Log("Vaya, has guardado una Lavanda venenosa");
        }
        if(flower == "Poison2")
        {
            num_poison2--;
            //Lavanda venenosa 1 = -3 puntos
            score = score - 3;
        }
        if(flower == "Poison3")
        {
            num_poison3--;
            //Lavanda venenosa 1 = -5 puntos
            score = score - 3;
        }
        
        

    }

    public void ThrowFlower(string flower)
    {
        if (flower == "Lavanda")
        {
            num_Lavanda--;
        }
        if (flower == "Camomila")
        {
            num_Camomila--;
        }
        if (flower == "PlantC")
        {
            num_C--;
        }
        if (flower == "Poison1")
        {
            num_poison--;
            //Lavanda venenoa 1 = -1 puntos
        }
        if (flower == "Poison2")
        {
            num_poison2--;
        }
        if (flower == "Poison3")
        {
            num_poison3--;
        }

    }
}
