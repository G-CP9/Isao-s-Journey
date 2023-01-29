using System.Collections;
using System.Collections.Generic;
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
    public Text Calendula_text;
   public int num_Calendula;
    public GameObject Icon_Calendula; //icon

    //Evil Lavanda
    public Text Evil_lavanda_text;
    public int num_e_lavanda;
    public GameObject Icon_Evil_Lavanda;

    //Flower Poisoned 2
    public Text Evil_camomila_text;
    public int num_e_camomila;
    public GameObject Icon_Evil_Camomila;

    //Flower Poisoned 3
    public Text Evil_calendula_text;
    public int num_e_calendula;
    public GameObject Icon_Evil_Calendula;


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
        Icon_Calendula.SetActive(false);
        Icon_Evil_Lavanda.SetActive(false);
        Icon_Evil_Camomila.SetActive(false);
        Icon_Evil_Calendula.SetActive(false);


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

        if(score > -1)
        {
            //Lavandas A
            Lavanda_txt.text = "x" + num_Lavanda.ToString();
            if (num_Lavanda == 1)
            {
                Icon_Lavanda.SetActive(true);
            }
            if (num_Lavanda == 0)
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

            //Calendula
            Calendula_text.text = "x" + num_Calendula.ToString();

            if (num_Calendula == 1)
            {
                Icon_Calendula.SetActive(true);
            }
            if (num_Calendula == 0)
            {
                Icon_Calendula.SetActive(false);
            }

            //Lavandas venenosas 1
            Evil_lavanda_text.text = "x" + num_e_lavanda.ToString();

            if (num_e_lavanda == 1)
            {
                Icon_Evil_Lavanda.SetActive(true);
            }
            if (num_e_lavanda == 0)
            {
                Icon_Evil_Lavanda.SetActive(false);
            }

            //Lavandas venenosas 2
            Evil_camomila_text.text = "x" + num_e_camomila.ToString();

            if (num_e_camomila == 1)
            {
                Icon_Evil_Camomila.SetActive(true);
            }
            if (num_e_camomila == 0)
            {
                Icon_Evil_Camomila.SetActive(false);
            }




            //Lavandas venenosas 3
            Evil_calendula_text.text = "x" + num_e_calendula.ToString();

            if (num_e_calendula == 1)
            {
                Icon_Evil_Calendula.SetActive(true);
            }
            if (num_e_calendula == 0)
            {
                Icon_Evil_Calendula.SetActive(false);
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

        else
        {

        }
       
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
                if (item == "Calendula")
                {
                    num_Calendula++;
                    
                }
                

            }

            if(poison)
            {
                if (item == "Lavanda")
                {
                    //Lavanda venenosa tipo 1
                    num_e_lavanda++;
                    
                    
                }

                if (item == "Camomila")
                {
                    //Lavanda venenosa tipo 2
                    num_e_camomila++;
                    
                    

                }

                if (item == "Calendula")
                {
                    //Lavanda venenosa tipo 2
                    num_e_calendula++;
                    

                    

                }
                
            }


            num_objects++;
            
        }

        
        
        
    }

    public void KeepFlower(string flower)
    {
        if(score > -1)
        {

            if (flower == "Lavanda")
            {
                num_Lavanda--;
                //Lavanda A = 1 punto
                score++;
            }
            if (flower == "Camomila")
            {
                num_Camomila--;
                //Lavanda B = 3 puntos
                score = score + 3;
            }
            if (flower == "Calendula")
            {
                num_Calendula--;
                //Lavanda C = 5 puntos
                score = score + 5;
            }
            if (flower == "Evil Lavanda")
            {
                num_e_lavanda--;
                //Lavanda venenosa 1 = -1 puntos
                score = score - 1;
                Debug.Log("Vaya, has guardado una planta venenosa");
            }
            if (flower == "Evil Camomila")
            {
                num_e_camomila--;
                //Lavanda venenosa 1 = -3 puntos
                score = score - 3;

            }
            if (flower == "Evil Calendula")
            {
                num_e_calendula--;
                //Lavanda venenosa 1 = -5 puntos
                score = score - 5;
            }

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
        if (flower == "Calendula")
        {
            num_Calendula--;
        }
        if (flower == "Evil Lavanda")
        {
            num_e_lavanda--;
            //Lavanda venenoa 1 = -1 puntos
        }
        if (flower == "Evil Camomila")
        {
            num_e_camomila--;
        }
        if (flower == "Evil Calendula")
        {
            num_e_calendula--;
        }

    }
}
