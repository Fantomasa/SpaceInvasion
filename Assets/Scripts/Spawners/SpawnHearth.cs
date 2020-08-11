using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHearth : MonoBehaviour
{
    [SerializeField] private GameObject hearth = default;
    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private const float C_SCREEN_PADDING = 0.2f;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Utils.GetScreenBounds();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Spawn()
    {
        int res = Random.Range(1, 10);

        if (res == 5)
        {
            GameObject go = Instantiate(hearth);
            go.transform.position = new Vector2(Random.Range(-screenBounds.x + C_SCREEN_PADDING, screenBounds.x - C_SCREEN_PADDING), screenBounds.y);
        }
    }
}
