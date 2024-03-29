using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConversationData", menuName = "ConversationNode", order = 1)]
public class ConversationNode : ScriptableObject
{
    public string text;
    public bool multiple;
    public bool last;
    public string option1;
    public string option2;
    public ConversationNode op1Conv;
    public ConversationNode op2Conv;
}
