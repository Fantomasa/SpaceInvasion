using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroid : MonoBehaviour
{
    private const float C_X_PADDING = 0.5f;

    [SerializeField] private float speed = 0.2f;
    private Vector3 newPosition;

    private Transform startMarker;
    private Vector3 endMarker;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Utils.GetScreenBounds();

        endMarker = GetAsteroidNewPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Utils.CheckDestroyGameObject(this.gameObject);
        Move();
    }

    private Vector3 GetAsteroidNewPosition()
    {
        float y = 0;
        if (transform.position.y >= 0)
        {
            y = Random.Range(-screenBounds.y, 0);
        }
        else
        {
            y = Random.Range(0, screenBounds.y);
        }

        float x = 0;
        if (transform.position.x > 0)
        {
            x = -transform.position.x - C_X_PADDING;
        }
        else
        {
            x = -transform.position.x + C_X_PADDING;
            
        }

        return new Vector3(x, y, transform.position.z);
    }

    private void Move()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, endMarker, step);
    }
}
