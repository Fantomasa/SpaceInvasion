using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShield : MonoBehaviour
{
    private Spaceship spashipScript;

    private float smooth = 5.0f;

    void Update()
    {
        transform.Rotate(0f, 0f, smooth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CollisionWithEnemy(collision))
        {
            GameController.AddRemoveShieldPoints(-1);
            CheckIsTimeToStopShield();
        }
    }

    private void CheckIsTimeToStopShield()
    {
        if (GameController.currentShieldPoints <= 0)
        {
            spashipScript = this.transform.parent.gameObject.GetComponent<Spaceship>();

            this.gameObject.SetActive(false);
            spashipScript.fireShieldIsActive = false;
        }
    }
}
