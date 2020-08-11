using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float movementSpeed = 20f;
    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb = GetComponent<Rigidbody2D>();
        MoveBullet();

    }
    // Update is called once per frame
    void Update()
    {
        Utils.CheckDestroyGameObject(this.gameObject);
    }

    private void MoveBullet()
    {
        rb.velocity = transform.right * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CollisionWithEnemy(collision))
        {
            Destroy(this.gameObject);
        }
    }
}
