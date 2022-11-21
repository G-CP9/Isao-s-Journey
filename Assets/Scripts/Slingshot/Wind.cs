using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wind : MonoBehaviour
{
    private SlingshotMinigameManager minigame;
    public Sprite green;
    public Sprite yellow;
    public Sprite red;
    private Image image;

    private void Awake()
    {
        minigame = SlingshotMinigameManager.Instance;
        image = GetComponent<Image>();
    }

    public void UpdateDirection()
    {
        transform.rotation = Quaternion.identity;
        transform.Rotate(Vector3.forward, minigame.windAngle);
    }

    public void UpdateColor()
    {
        if (minigame.windPower == minigame.windPowerValues[0])
        {
            image.sprite = green;
        }
        else if (minigame.windPower == minigame.windPowerValues[1])
        {
            image.sprite = yellow;
        }
        else if (minigame.windPower == minigame.windPowerValues[2])
        {
            image.sprite = red;
        }
    }
}
