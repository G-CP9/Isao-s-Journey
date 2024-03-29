using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endline : MonoBehaviour
{
    public static bool end;
    public GameObject endText;
    public GameObject screenControls;

    private void Start()
    {
        end = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            end = true;
            screenControls.gameObject.GetComponent<VirtualJoystick>().Hide();
            endText.SetActive(true);
        }
    }
}
