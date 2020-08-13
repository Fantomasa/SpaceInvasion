using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusFirePoint : MonoBehaviour
{
    private void Update()
    {
        Utils.CheckDestroyGameObject(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CollisionWithSpaceship(collision))
        {
            Destroy(this.gameObject);
        }
    }
}
