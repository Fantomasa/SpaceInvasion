using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumAsteroid : MonoBehaviour
{
    [SerializeField] private GameObject[] smallWhiteAsteroidsArr = default;
    private int asteroidIdx;

    [SerializeField] private int smallAsteroidsSpawn = 3;
    [SerializeField] private float xRandomRange = 0.2f;

    [SerializeField] private int maxHealth = 7;
    private int currentHealth;

    [SerializeField] private float rotationSpeed = 2f;
    private Vector3 rotation;

    private AudioSource hitOudio;
    private bool isInSpawningAsteroids = false;

    // Start is called before the first frame update
    void Start()
    {
        hitOudio = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        asteroidIdx = Utils.GetRandomNumberInclusive(0, smallWhiteAsteroidsArr.Length - 1);
        rotation = Utils.GetRotation();
    }

    private void Update()
    {
        Utils.CheckDestroyGameObject(this.gameObject);
        Utils.RotateGameObject(this.gameObject, rotation, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CollisionWithBullet(collision))
        {
            Destroy(collision.gameObject);
            CollisionWithBullet();
        }
        else if (Utils.CollisionWithEarth(collision))
        {
            SpawnSmallWhiteAsteroid(3);
            GameController.AddRemoveHealth(-2);
            Destroy(this.gameObject);
        }
        else if (Utils.CollisionWithSpaceship(collision))
        {
            SpawnSmallWhiteAsteroid(3);
            GameController.AddRemoveHealth(-2);
            Destroy(this.gameObject);
        }
        else if (Utils.CollisionWithShield(collision))
        {
            SpawnSmallWhiteAsteroid(3);
            Destroy(this.gameObject);
        }
    }

    private void CollisionWithBullet()
    {
        if (currentHealth >= 0)
        {
            currentHealth--;
            hitOudio.Play();
        }
        else
        {
            Destroy(this.gameObject);
            SpawnSmallWhiteAsteroid(smallAsteroidsSpawn);            
        }
    }

    private void SpawnSmallWhiteAsteroid(int count)
    {
        if (isInSpawningAsteroids) return;

        isInSpawningAsteroids = true;

        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(transform.position.x - xRandomRange, transform.position.x + xRandomRange);

            Vector2 position = new Vector2(x, transform.position.y);

            SpawnSmallAsteroidPosition(position);
        }
    }

    private void SpawnSmallAsteroidPosition(Vector3 position)
    {
        Instantiate(smallWhiteAsteroidsArr[asteroidIdx], position, Quaternion.identity);
    }
}
