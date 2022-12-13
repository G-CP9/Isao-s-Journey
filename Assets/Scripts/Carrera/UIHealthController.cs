using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthController : MonoBehaviour
{
    public Sprite[] spriteArray;

    public void ChangeSprite(int index)
    {
        GetComponent<Image>().sprite = spriteArray[index];
    }
}
