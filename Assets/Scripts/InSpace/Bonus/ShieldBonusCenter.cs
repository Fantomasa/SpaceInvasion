using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBonusCenter : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        this.transform.Rotate(0f, rotateSpeed, 0f);
    }
}
