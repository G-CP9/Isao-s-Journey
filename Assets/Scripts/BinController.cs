using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class BinController : MonoBehaviour
{
    public bool bin_open;
    string flower;
    public ToolBarController toolBar;




    private void Start()
    {
        bin_open = false;

        toolBar = FindObjectOfType<ToolBarController>();



    }
    public void OpenState(bool state)
    {
        bin_open = state;
        if (bin_open)
        {
            Debug.Log("bin Open");
        }
        else
        {
            Debug.Log("bin Close");
        }
    }

    private void Update()
    {

        if (bin_open)
        {
            Input_flower();

            toolBar.ThrowFlower(flower);
            flower = "";
        }

    }


    private void Input_flower()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (toolBar.num_Lavanda > 0)
            {
                flower = "Lavanda";
                toolBar.num_objects--;
            }
            else
            {
                Debug.Log("No tienes flores A");
            }

        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (toolBar.num_Camomila > 0)
            {
                flower = "Camomila";
                toolBar.num_objects--;

            }
            else
            {
                Debug.Log("No tienes flores B");
            }

        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            if (toolBar.num_C > 0)
            {
                flower = "PlantC";
                toolBar.num_objects--;

            }
            else
            {
                Debug.Log("No tienes flores C");
            }

        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            if (toolBar.num_poison > 0)
            {
                flower = "Poison1";
                toolBar.num_objects--;

            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }

        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            if (toolBar.num_poison2 > 0)
            {
                flower = "Poison2";
                toolBar.num_objects--;

            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }

        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            if (toolBar.num_poison3 > 0)
            {
                flower = "Poison3";
                toolBar.num_objects--;

            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }
    }




}
