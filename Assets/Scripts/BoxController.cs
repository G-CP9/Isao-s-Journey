using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public bool box_open;
    string flower;
    public ToolBarController toolBar;
    public bool isThrowing;

    
    

    private void Start()
    {
        box_open = false;

        toolBar = FindObjectOfType<ToolBarController>();

        

    }
    public void OpenState(bool state)
    {
        box_open = state;
        if(box_open)
        {
            Debug.Log("Box Open");
        }
        else
        {
            Debug.Log("Box Close");
        }
    }

    private void Update()
    {
        
        if (box_open)
        {
            Input_flower();

            toolBar.KeepFlower(flower);
            flower = "";
        }

    }

   
    private void Input_flower()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            if(toolBar.num_Lavanda > 0)
            {
                flower = "Lavanda";
                toolBar.num_objects--;
                isThrowing = true;
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
                isThrowing = true;
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
                isThrowing = true;
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
                isThrowing = true;
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
                isThrowing = true;
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
                isThrowing = true;
            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }
    }

}
