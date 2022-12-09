using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotSounds : MonoBehaviour
{
    public Pot_controller pot_Controller;
    public AudioSource sound;
    public AudioClip complete;
    public AudioClip fail;
    int estado;

    int i = 0;

    private void Start()
    {
        pot_Controller = GetComponent<Pot_controller>();        
    }
    private void Update()
    {
        estado = pot_Controller.estado;

        if (estado == 4)
        {
            while (i < 2)
            {
                sound.clip = complete;
                PlaySound();
                i++;
            }
        }

        if (estado == 5)
        {
            i = 0;

            while (i < 2)
            {
                sound.clip = fail;
                PlaySound();
                i++;
            }
            
        }



    }

    void PlaySound()
    {
        if(!sound.isPlaying)
        {
            sound.Play();
        }
       
        
    }
    
 
   
}
