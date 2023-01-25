using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeControllerPlayer : MonoBehaviour
{
    public NodeViewManager view;
    public ConversationNode currentNode;
    public PlayerTalk talker;

    void Start()
    {
        UpdateView();
    }

    public void UpdateNode(Button selectedOp)
    {
        if (currentNode.last)
        {
            talker.EndTalk();
        }
        else
        {
            if (selectedOp.name == "Opcion1")
            {
                currentNode = currentNode.op1Conv;
            }
            else
            {
                currentNode = currentNode.op2Conv;
            }
            UpdateView();
        }
    }

    void UpdateView()
    {
        view.InsertNode(currentNode);
    }
}
