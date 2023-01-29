using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_manager : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Swap_scene()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void Return()
    {
        Invoke("Swap_scene", 1.0f);
    }
}
