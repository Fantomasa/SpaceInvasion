using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShootingBonus : MonoBehaviour
{
    // Update is called once per frame
    void Update()
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
