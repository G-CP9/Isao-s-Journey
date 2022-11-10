using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowInput : MonoBehaviour
{
    private SlingshotMinigameManager minigame;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        minigame = SlingshotMinigameManager.Instance;
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
        transform.Rotate(Vector3.forward, minigame.throwAngle);
    }

    public void SetMaxPower()
    {
        slider.maxValue = minigame.MAX_THROW_POWER;
    }

    public void SetPower()
    {
        slider.value = minigame.throwPower;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
