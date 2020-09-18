using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithJoystick : MonoBehaviour
{
    [SerializeField] private GameObject engineFire = default;

    [SerializeField] private Sprite moveSprite = default;
    private Sprite oldSprite;

    [SerializeField] float movementSpeed = 100f;

    private bool shipIsMoving;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private float joystickHorizontal = 0f;
    private float joystickVertical = 0f;

    public Joystick joystick;

    private Vector2 screenBounds;

    private void Start()
    {
        shipIsMoving = false;

        engineFire.SetActive(false);

        spriteRenderer = GetComponent<SpriteRenderer>();
        oldSprite = spriteRenderer.sprite;

        rb = GetComponent<Rigidbody2D>();
        screenBounds = Utils.GetScreenBounds();
    }

    private void FixedUpdate()
    {
        Move();

        if (shipIsMoving)
        {
            ChangeSpaceshipToMovingSprite();
        }
        else
        {
            ChangeSpaceshipToHoldingSprite();
        }
    }

    private void ChangeSpaceshipToMovingSprite()
    {
        spriteRenderer.sprite = moveSprite; //change sprite
        engineFire.SetActive(true); //see engineFire
    }

    private void ChangeSpaceshipToHoldingSprite()
    {
        spriteRenderer.sprite = oldSprite; //change sprite
        engineFire.SetActive(false); //remove engineFire
    }

    private void Move()
    {
        if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            shipIsMoving = false;
            return;
        }

        shipIsMoving = true;

        joystickHorizontal = joystick.Horizontal * movementSpeed;
        joystickVertical = joystick.Vertical * movementSpeed;

        MoveSpaceship(new Vector2(joystickHorizontal, joystickVertical));
    }

    private void MoveSpaceship(Vector2 newPosition)
    {
        Vector2 spaceshipPosition = IsInBounds(newPosition);

        transform.position = Vector2.MoveTowards(transform.position, spaceshipPosition, movementSpeed * Time.deltaTime);
    }

    private Vector2 IsInBounds(Vector2 spaceshipNewPosition)
    {
        if (spaceshipNewPosition.x < 0)
        {
            spaceshipNewPosition.x = Mathf.Max(spaceshipNewPosition.x, -screenBounds.x);
        }
        else if (spaceshipNewPosition.x > 0)
        {
            spaceshipNewPosition.x = Mathf.Min(spaceshipNewPosition.x, screenBounds.x);
        }

        if (spaceshipNewPosition.y < 0)
        {
            spaceshipNewPosition.y = Mathf.Max(spaceshipNewPosition.y, -screenBounds.y);
        }
        else if (spaceshipNewPosition.y > 0)
        {
            spaceshipNewPosition.y = Mathf.Min(spaceshipNewPosition.y, screenBounds.y);
        }

        return spaceshipNewPosition;
    }
}
