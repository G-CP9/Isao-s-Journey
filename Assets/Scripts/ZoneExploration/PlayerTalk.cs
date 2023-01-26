using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTalk : MonoBehaviour
{
    public GameObject instruccion;
    public GameObject talkBox;
    public GameObject optionsInterface;
    public GameObject screenControls;
    public PlayerController player;
    bool canTalk = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //instruccion.SetActive(true);
            canTalk = true;
            Talk();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            instruccion.SetActive(false);
            canTalk = false;
        }
    }

    public void Talk()
    {
        if (canTalk)
        {
            player.LockMovement();
            instruccion.SetActive(false);
            screenControls.gameObject.GetComponent<VirtualJoystick>().Hide();
            talkBox.SetActive(true);
            optionsInterface.SetActive(true);
        }
    }

    public void EndTalk()
    {
        this.gameObject.transform.parent.GetComponent<PlayerController>().UnlockMovement();
        //this.gameObject.transform.parent.GetComponent<PlayerController>().talked = true;
        player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //instruccion.SetActive(true);
        screenControls.SetActive(true);
        talkBox.SetActive(false);
        optionsInterface.SetActive(false);
        this.gameObject.SetActive(false);
    }

    /*void StartTalk()
    {
        if (canTalk)
        {
            Talk();
        }
    }*/
}
