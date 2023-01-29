using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinController : MonoBehaviour
{
    public bool bin_open;
    string flower;
    public ToolBarController toolBar;

    //Sound
    public AudioSource bin_sound;
    public AudioClip throw_flower;
    public AudioClip open_bin;



    private void Start()
    {
        bin_open = false;

        //toolBar = FindObjectOfType<ToolBarController>();



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
            bin_sound.clip = throw_flower;
            if (toolBar.num_Lavanda > 0)
            {
                flower = "Lavanda";
                toolBar.num_objects--;
                bin_sound.Play();
            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            bin_sound.clip = throw_flower;
            if (toolBar.num_Camomila > 0)
            {
                flower = "Camomila";
                toolBar.num_objects--;
                bin_sound.Play();

            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            bin_sound.clip = throw_flower;
            if (toolBar.num_Calendula > 0)
            {
                flower = "Calendula";
                toolBar.num_objects--;
                bin_sound.Play();

            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            bin_sound.clip = throw_flower;
            if (toolBar.num_e_lavanda > 0)
            {
                flower = "Evil Lavanda";
                toolBar.num_objects--;
                bin_sound.Play();

            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }

        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            bin_sound.clip = throw_flower;
            if (toolBar.num_e_camomila > 0)
            {
                flower = "Evil Camomila";
                toolBar.num_objects--;
                bin_sound.Play();

            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }

        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            bin_sound.clip = throw_flower;
            if (toolBar.num_e_calendula > 0)
            {
                flower = "Evil Calendula";
                toolBar.num_objects--;
                bin_sound.Play();

            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }
    }


        //Controles táctiles

    public void Input_flower_touch(string flor)
    {
        if (flor == "Lavanda")
        {
            bin_sound.clip = throw_flower;
            if (toolBar.num_Lavanda > 0)
            {
                flower = "Lavanda";
                toolBar.num_objects--;
                bin_sound.Play();
            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }

        if (flor == "Camomila")
        {
            bin_sound.clip = throw_flower;
            if (toolBar.num_Camomila > 0)
            {
                flower = "Camomila";
                toolBar.num_objects--;
                bin_sound.Play();

            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }

        if (flor == "Calendula")
        {
            bin_sound.clip = throw_flower;
            if (toolBar.num_Calendula > 0)
            {
                flower = "Calendula";
                toolBar.num_objects--;
                bin_sound.Play();

            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }

        if (flor == "Evil Lavanda")
        {
            bin_sound.clip = throw_flower;
            if (toolBar.num_e_lavanda > 0)
            {
                flower = "Evil Lavanda";
                toolBar.num_objects--;
                bin_sound.Play();

            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }

        if (flor == "Evil Camomila")
        {
            bin_sound.clip = throw_flower;
            if (toolBar.num_e_camomila > 0)
            {
                flower = "Evil Camomila";
                toolBar.num_objects--;
                bin_sound.Play();

            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }

        if (flor == "Evil Calendula")
        {
            bin_sound.clip = throw_flower;
            if (toolBar.num_e_calendula > 0)
            {
                flower = "Evil Calendula";
                toolBar.num_objects--;
                bin_sound.Play();

            }
            else
            {
                Debug.Log("No tienes flores de ese tipo");
            }

        }
    }


    public void Opening()
    {
        bin_sound.clip = open_bin;
        bin_sound.Play();

    }

    public void Close()
    {
        bin_sound.clip = open_bin;
        bin_sound.Play();
    }



}
