using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackgroundAsteroid : MonoBehaviour
{
    [SerializeField] private const float C_X_SCREEN_PADDING = 0.2f;
    [SerializeField] private const float C_Y_SCREEN_PADDING = 1.5f;

    [SerializeField] GameObject[] asteroids = default;
    [SerializeField] private float spawnTime = 1f;
    private int asteroidIdx;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        InvokeRepeating("SpawnAsteroid", spawnTime, spawnTime);
    }


    private void SpawnAsteroid()
    {
        asteroidIdx = Utils.GetRandomNumberInclusive(0, asteroids.Length - 1);

        GameObject go = Instantiate(asteroids[asteroidIdx]);

        int randomX = Utils.GetRandomNumberInclusive(0, 1);
        float x = 0;
        if (randomX == 0)
        {
            x = screenBounds.x;
        }
        else
        {
            x = -screenBounds.x;
        }

        go.transform.position = new Vector2(x, Random.Range(-screenBounds.y + C_Y_SCREEN_PADDING, screenBounds.y - C_Y_SCREEN_PADDING));
    }
}
