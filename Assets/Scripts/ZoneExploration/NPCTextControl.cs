using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTextControl : MonoBehaviour
{
    public GameObject textBox1;
    public GameObject textBox2;
    PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerController>();
            if (!player.talked)
                textBox1.SetActive(true);
            else
                textBox2.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerController>();
            if (!player.talked)
                textBox1.SetActive(false);
            else
                textBox2.SetActive(false);
        }
    }
}
