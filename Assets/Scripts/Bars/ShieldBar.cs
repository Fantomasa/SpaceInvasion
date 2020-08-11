using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public static Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public static void SetMaxShieldPoints(int maxShieldPoints)
    {
        slider.maxValue = maxShieldPoints;
        slider.value = maxShieldPoints;
    }

    public static void SetShieldPoints(int shieldPoints)
    {
        slider.value = shieldPoints;
    }
}
