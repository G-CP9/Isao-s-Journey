using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KyaraTalk : MonoBehaviour
{

    public GameObject instruccion;
    public GameObject talkBox;
    public GameObject optionsInterface;
    public PlayerController player;
    bool canTalk = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            instruccion.SetActive(true);
            canTalk = true;
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

    private void Talk()
    {
        player.LockMovement();
        instruccion.SetActive(false);
        talkBox.SetActive(true);
        optionsInterface.SetActive(true);
    }

    public void EndTalk()
    {
        player.UnlockMovement();
        instruccion.SetActive(true);
        talkBox.SetActive(false);
        optionsInterface.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && canTalk)
        {
            Talk();
        }
    }
}
