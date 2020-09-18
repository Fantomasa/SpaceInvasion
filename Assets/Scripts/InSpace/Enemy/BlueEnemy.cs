using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] bonusObjects = default;
    [SerializeField] private GameObject explodeObject = default;
    [SerializeField] private float destroyExplosionFireAfter = 2f;

    private bool isInCollision = false;

    private void Start()
    {
        //min = transform.position.x;
        //max = transform.position.x + 3;
    }

    private void FixedUpdate()
    {
        //MoveCurrent();
    }

    private void MoveCurrent()
    {
        //transform.position = new Vector2(Mathf.PingPong(Time.time, max - min) + min, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CollisionWithBullet(collision) || Utils.CollisionWithSpaceship(collision) || Utils.CollisionWithShield(collision))
        {
            if (!isInCollision)
            {
                isInCollision = true;
                DestroyBlueEnemy();
            }

        }
    }

    private void DestroyBlueEnemy()
    {
        GameObject go = Instantiate(explodeObject, transform.position, Quaternion.identity);
        Utils.InstBonusGo(this.transform, bonusObjects);

        Destroy(this.gameObject);
        Destroy(go, destroyExplosionFireAfter);
    }
}
