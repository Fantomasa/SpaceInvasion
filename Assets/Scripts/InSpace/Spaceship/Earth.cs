using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CollisionWithEnemy(collision))
        {
            GameController.AddRemoveHealth(-1);
        }
    }
}
