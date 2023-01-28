using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrier : MonoBehaviour
{
    public GameObject reminder;
    public GameObject screenControls;
    PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerController>();

            if (!player.talked)
            {
                player.LockMovement();
                screenControls.gameObject.GetComponent<VirtualJoystick>().Hide();
                reminder.SetActive(true);
            }
            else
                this.gameObject.SetActive(false);
        }
    }

    public void Back()
    {
        reminder.SetActive(false);
        screenControls.SetActive(true);
        player.UnlockMovement();
    }
}
