using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class Sound_Manager : MonoBehaviour
{
    //Player
    public Player player;
    AudioSource game_song;

    // Start is called before the first frame update
    void Start()
    {

        game_song =  GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {
    }

    void Songs()
    {
        
    }
}
