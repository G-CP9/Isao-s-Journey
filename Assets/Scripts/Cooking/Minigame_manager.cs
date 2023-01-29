using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Minigame_manager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject objects;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        objects.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        objects.SetActive(true);
    }
}
