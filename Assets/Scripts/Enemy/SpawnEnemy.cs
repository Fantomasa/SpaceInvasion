using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private const float C_X_SCREEN_PADDING = 0.2f;
    [SerializeField] private const float C_Y_SCREEN_PADDING = 0.2f;

    [SerializeField] private GameObject[] Enemies = default;
    [SerializeField] private float spawnTime = 1f;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        InvokeRepeating("SpawnEnemyObject", spawnTime, spawnTime);
    }

    private void SpawnEnemyObject()
    {
        int enemyIdx = Utils.GetRandomNumberInclusive(0, Enemies.Length - 1);
        GameObject go = Instantiate(Enemies[enemyIdx]);
        go.transform.position = new Vector2(Random.Range(-screenBounds.x + C_X_SCREEN_PADDING, screenBounds.x - C_X_SCREEN_PADDING), screenBounds.y + C_Y_SCREEN_PADDING);
    }
}
