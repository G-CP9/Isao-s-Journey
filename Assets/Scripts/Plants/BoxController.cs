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
            if (toolBar.num_Calendula > 0)
            {
                flower = "Calendula";
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
            if (toolBar.num_e_lavanda > 0)
            {
                flower = "Evil Lavanda";
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
            if (toolBar.num_e_camomila > 0)
            {
                flower = "Evil Camomila";
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
            if (toolBar.num_e_calendula > 0)
            {
                flower = "Evil Calendula";
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
