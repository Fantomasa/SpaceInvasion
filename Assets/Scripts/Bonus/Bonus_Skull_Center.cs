using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_Skull_Center : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0f, speed, 0f);
    }
}
