using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerMinigame : MonoBehaviour
{
    public GameObject instruccion;
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
        instruccion.SetActive(false);
        player.UnlockMovement();
    }

}
