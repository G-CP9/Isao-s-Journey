using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeController : MonoBehaviour
{
    public NodeViewManager view;
    public ConversationNode currentNode;

    void Start()
    {
        UpdateView();
    }

    void Update()
    {
        
    }

    public void UpdateNode(Button selectedOp)
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

    void UpdateView()
    {
        view.InsertNode(currentNode);
    }
}
