using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusBar : MonoBehaviour
{
    private static Slider slider;
    private float currentTime;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {

        slider = GetComponent<Slider>();

        Debug.Log(slider.maxValue);

        slider.value = slider.maxValue;
        currentTime = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseTimer();
        if (timer >= 1f)
        {
            changeSliderValue(-1);
            timer = 0f;
        }
    }

    private void IncreaseTimer()
    {
        timer += Time.deltaTime;
    }

    public static void SetMaxTime(float time)
    {
        slider.maxValue = time;
        slider.value = time;
    }

    public void changeSliderValue(float value)
    {
        float newValue = currentTime - value;
        if (newValue >= 0)
            slider.value = value;
    }

}
