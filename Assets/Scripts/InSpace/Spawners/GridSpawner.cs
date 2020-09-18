using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] private float C_SCREEN_X_MARGIN = -2f;
    [SerializeField] private float C_SCREEN_Y_MARGIN = 3.5f;

    [SerializeField] private float C_SPACESHIP_MARGIN = 1f;

    [SerializeField] private int rows = 0;
    [SerializeField] private int colls = 0;

    private int[,] grid;
    [SerializeField] private GameObject enemyShip = default;

    [SerializeField] private float spawnTime = 1f;
    private float nextWave = 0f;
    [SerializeField] private float moveObjectSpeed = 10f;

    private Vector2 screenBounds;
    private Queue<Vector2> positions;

    private List<EnemyObject> enemyList;
    private List<bool> enemyTransformIsFinished;
    private bool spawnTransformIsFinished;

    private class EnemyObject
    {
        public GameObject go;
        public Vector2 newPos;

        public EnemyObject(GameObject go, Vector2 newPos)
        {
            this.go = go;
            this.newPos = newPos;
        }
    }

    void Start()
    {
        screenBounds = Utils.GetScreenBounds();

        positions = CreateGrid();
        enemyList = new List<EnemyObject>(positions.Count);
        enemyTransformIsFinished = new List<bool>(positions.Count);

    }

    private void Update()
    {
        CheckIsWaveTime();

        for (int goIdx = 0; goIdx < enemyList.Count; goIdx++)
        {
            MoveGameObjectToPosition(enemyList[goIdx].go, enemyList[goIdx].newPos);
        }
    }

    private void CheckIsWaveTime()
    {
        if (positions.Count <= 0) return;

        if (nextWave <= Time.time)
        {
            GameObject go = SpawnEnemyObject();
            nextWave = Time.time + spawnTime;

            Vector2 newPos = positions.Dequeue();

            enemyList.Add(new EnemyObject(go, newPos));
        }
    }

    private void MoveGameObjectToPosition(GameObject go, Vector2 position)
    {
        if (go == null) return;

        go.transform.position = Vector2.MoveTowards(go.transform.position, position, moveObjectSpeed * Time.deltaTime);
    }

    private GameObject SpawnEnemyObject()
    {
        GameObject go = Instantiate(enemyShip);
        go.transform.position = new Vector2(screenBounds.x, Random.Range(0, screenBounds.y));

        return go;
    }

    private Queue<Vector2> CreateGrid()
    {
        Queue<Vector2> result = new Queue<Vector2>(rows * colls);
        grid = new int[rows, colls];

        Vector2 currentTransform = new Vector2(C_SCREEN_X_MARGIN, C_SCREEN_Y_MARGIN);

        for (int rowIdx = 0; rowIdx < grid.GetLength(0); rowIdx++)
        {
            for (int collIdx = 0; collIdx < grid.GetLength(1); collIdx++)
            {                
                result.Enqueue(currentTransform);
                currentTransform = new Vector2(currentTransform.x + C_SPACESHIP_MARGIN, currentTransform.y);
            }

            currentTransform = new Vector2(C_SCREEN_X_MARGIN, currentTransform.y - C_SPACESHIP_MARGIN);
        }

        return result;
    }
}
