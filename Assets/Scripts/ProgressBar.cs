using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    public float FillSpeed = 0.5f;
    private float targetProgress = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        slider= gameObject.GetComponent<Slider>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
            slider.value += FillSpeed * Time.deltaTime;
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
        Debug.Log(targetProgress);
    }
}