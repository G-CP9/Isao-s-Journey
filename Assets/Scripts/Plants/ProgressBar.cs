using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;

    public void SetInitProgress()
    {
        slider.maxValue = 30;
        slider.minValue = 0;
    }

    public void SetProgress(int score)
    {
        slider.value = score;
    }
}
