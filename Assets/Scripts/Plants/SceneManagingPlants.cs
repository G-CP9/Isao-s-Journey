using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagingPlants: MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("Despor");
    }

    public void Next()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("Despor2");
    }
}
