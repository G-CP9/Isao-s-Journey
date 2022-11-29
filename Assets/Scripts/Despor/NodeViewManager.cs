using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeViewManager : MonoBehaviour
{
    public TextMeshPro text;
    public Button op1Button;
    public Button op2Button;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    public void InsertNode(ConversationNode node)
    {
        text.text = node.text;
        op1Button.GetComponentInChildren<TextMeshProUGUI>().text = node.option1;
        if (node.multiple)
        {
            op2Button.gameObject.SetActive(true);
            op2Button.GetComponentInChildren<TextMeshProUGUI>().text = node.option2;
        }
        else
        {
            op2Button.gameObject.SetActive(false);
        }
    }

}
