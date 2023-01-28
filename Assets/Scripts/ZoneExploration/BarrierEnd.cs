using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierEnd : MonoBehaviour
{
    public GameObject sign;
    public GameObject screenControls;
    PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerController>();
            player.LockMovement();
            screenControls.gameObject.GetComponent<VirtualJoystick>().Hide();
            sign.SetActive(true);
        }
    }

    public void Back()
    {
        sign.SetActive(false);
        screenControls.SetActive(true);
        player.UnlockMovement();
    }
}
