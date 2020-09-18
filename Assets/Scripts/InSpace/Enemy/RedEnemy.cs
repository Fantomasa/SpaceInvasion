using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] bonusObjects = default;
    [SerializeField] private GameObject explodeObject = default;
    [SerializeField] private float destroyExplosionFireAfter = 2f;

    private Rigidbody2D rb;
    private Vector2 screenBounds;

    private bool isInDestroingEnemy = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        Utils.CheckDestroyGameObject(this.gameObject);
    }

    private void Move()
    {
        //Move Enemy to center so we can hit the planet
        float x = 0;
        if (transform.position.x >= 0)
        {
            x = Random.Range(-1f, 0f);
        }
        else if (transform.position.x < 0)
        {
            x = Random.Range(0, 1f);
        }

        rb.velocity = new Vector2(x, -screenBounds.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CollisionWithEarth(collision) || Utils.CollisionWithBullet(collision) || Utils.CollisionWithShield(collision) || Utils.CollisionWithSpaceship(collision))
        {
            DestroyRedEnemy();
        }
    }

    private void DestroyRedEnemy()
    {
        if (isInDestroingEnemy) return;

        isInDestroingEnemy = true;

        Destroy(this.gameObject);


        GameObject go = Instantiate(explodeObject, transform.position, Quaternion.identity);
        Utils.InstBonusGo(this.transform, bonusObjects);
        
        Destroy(go, destroyExplosionFireAfter);
    }
}
