using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroid : MonoBehaviour
{
    [SerializeField] private GameObject[] bonusObjects = default;
    [SerializeField] private GameObject smallAsteroidPartigleSystem = default;
    [SerializeField] private float destroyParticlesAfter = 1f;

    [SerializeField] private float maxHealth = 3f;
    private float currentHealth;

    [SerializeField] private float minGravityScale = 0.02f;
    [SerializeField] private float maxGravityScale = 0.1f;

    private Rigidbody2D rb;

    [SerializeField] private float rotationSpeed = 3f;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = GetGravityScale();

        currentHealth = maxHealth;

        rotation = Utils.GetRotation(); //to know where we gonna rotate
    }

    private void Update()
    {
        Utils.CheckDestroyGameObject(this.gameObject);
        Utils.RotateGameObject(this.gameObject, rotation, rotationSpeed);
    }

    private float GetGravityScale()
    {
        float res = Random.Range(minGravityScale, maxGravityScale);

        return res;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CollisionWithBullet(collision))
        {
            Destroy(collision.gameObject);
            OnCollisionWithBullet();
        }
        else if (Utils.CollisionWithEarth(collision))
        {
            GameController.AddRemoveHealth(-1);
            DestroySmallAsteroid();
        }
        else if (Utils.CollisionWithSpaceship(collision))
        {
            GameController.AddRemoveHealth(-1);
            DestroySmallAsteroid();
        }
        else if (Utils.CollisionWithShield(collision))
        {
            GameController.AddRemoveShieldPoints(-1);
            DestroySmallAsteroid();
        }
    }

    private void OnCollisionWithBullet()
    {
        if (currentHealth >= 0)
        {
            currentHealth--;
        }
        else
        {
            DestroySmallAsteroid();
        }

    }

    private void DestroySmallAsteroid()
    {
        Destroy(this.gameObject);

        GameObject go = Instantiate(smallAsteroidPartigleSystem, transform.position, Quaternion.identity);
        Utils.InstBonusGo(this.transform, bonusObjects);
                
        Destroy(go, destroyParticlesAfter);
    }
}
