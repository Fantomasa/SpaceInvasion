using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearth : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Utils.GetScreenBounds();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Utils.CheckDestroyGameObject(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CollisionWithSpaceship(collision) || Utils.CollisionWithShield(collision))
        {

            GameController.AddRemoveHealth(1);
            Destroy(this.gameObject);
        }
    }
}
