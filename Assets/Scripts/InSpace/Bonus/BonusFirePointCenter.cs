﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusFirePointCenter : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0f, rotateSpeed, 0f);
    }
}
