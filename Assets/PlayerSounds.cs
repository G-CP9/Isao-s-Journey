using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource walk;
    public AudioSource pick;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WalkSound()
    {
        if (!walk.isPlaying)
        {
            walk.Play();
        }
    }

    
    void Idle()
    {
        walk.Stop();
        pick.Stop();
    }

    void Picking()
    {
        if (!pick.isPlaying)
        {
            pick.Play();
        }
    }
}
