using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerMinigame : MonoBehaviour
{
    public GameObject instruccion;
    public GameObject reminder;
    public GameObject screenControls;
    public string minigame;
    PlayerController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.LockMovement();
            screenControls.SetActive(false);
            if (!player.talked)
                reminder.SetActive(true);
            else
                instruccion.SetActive(true);
        }
    }

    public void Go()
    {
        instruccion.SetActive(false);
        SceneManager.LoadScene(minigame);
    }

    public void Back()
    {
        reminder.SetActive(false);
        instruccion.SetActive(false);
        screenControls.SetActive(true);
        player.UnlockMovement();
    }

}
