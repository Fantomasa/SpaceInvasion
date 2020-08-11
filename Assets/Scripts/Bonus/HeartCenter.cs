using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCenter : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5f;

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        this.transform.Rotate(0f, rotateSpeed, 0f);
    }
}
