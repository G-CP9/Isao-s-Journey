using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject soundButton;
    public Sprite soundOn;
    public Sprite soundOff;
    private Image image;

    private void Awake()
    {
        image = soundButton.GetComponent<Image>();
    }

    public void OnPlayButtonClick()
    {
        Debug.Log("Initiating Despor Scene");
        SceneManager.LoadScene(sceneName:"Despor");
    }

    public void OnExitButtonClick()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void onSoundButtonClick()
    {
        if (Game.Instance.sound)
        {
            Game.Instance.sound = false;
            image.sprite = soundOff;
        }
        else
        {
            Game.Instance.sound = true;
            image.sprite = soundOn;
        }
    }
}
