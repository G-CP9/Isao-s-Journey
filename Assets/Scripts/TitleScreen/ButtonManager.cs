using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        print("Wiiiiiii!");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void onSoundButtonClick()
    {
        if (Game.Instance.sound)
        {
            Game.Instance.sound = false;
            print("Sound OFF");
        }
        else
        {
            Game.Instance.sound = true;
            print("Sound ON");
        }
    }
}
