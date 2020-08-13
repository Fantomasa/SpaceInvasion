using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_Skull : MonoBehaviour
{
    void Update()
    {
        Utils.CheckDestroyGameObject(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CollisionWithSpaceship(collision))
            Destroy(this.gameObject);
    }
}
