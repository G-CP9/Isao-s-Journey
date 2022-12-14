using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTextControl : MonoBehaviour
{
    public GameObject textBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textBox.SetActive(false);
        }
    }
}
