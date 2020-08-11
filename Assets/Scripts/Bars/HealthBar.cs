using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public static void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public static void SetHealth(int health)
    {
        slider.value = health;
    }
}
