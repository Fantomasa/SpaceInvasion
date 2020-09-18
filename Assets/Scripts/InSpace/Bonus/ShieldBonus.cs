using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBonus : MonoBehaviour
{
    void Update()
    {
        Utils.CheckDestroyGameObject(this.gameObject);
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CollisionWithSpaceship(collision) || Utils.CollisionWithShield(collision))
        {
            GameController.AddRemoveShieldPoints(+1);
            Destroy(this.gameObject);
        }
    }
}
