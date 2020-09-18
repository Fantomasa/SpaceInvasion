using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBulletsCircle : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0f, 0f, rotateSpeed);
    }
}
