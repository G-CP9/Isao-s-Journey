using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject screenControls;
    public PlayerController player;

    public void Begin()
    {
        gameObject.SetActive(false);
        screenControls.SetActive(true);
        player.UnlockMovement();
    }
}
