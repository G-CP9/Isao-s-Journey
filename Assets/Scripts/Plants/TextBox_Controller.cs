using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextBox_Controller : MonoBehaviour
{
    public Player player;
    public BoxController box;
    public BinController bin;

    public Text text_box1;
    public Text text_box2;

    public string box_text;
    public string bin_text;

    private void Start()
    {
        text_box1.text = "";
        text_box2.text = "";
    }

    private void Update()
    {
        if(box.box_open)
        {
            Box_Text();
        }
        else if(bin.bin_open)
        {
            Bin_Text();
        }
        else
        {
            Clear_Text();
        }
        
        Debug.Log(box.box_open);

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
        if(text_box1.text != "")
        {
            text_box1.text = "";

        }
    }

}
