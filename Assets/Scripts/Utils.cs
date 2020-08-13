using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    private static Vector2 screenBounds = GetScreenBounds();

    private static float C_SCREEN_OFFSET = 1f;

    private static float clicked = 0;
    private static float clicktime = 0;
    private static float clickdelay = 0.3f;

    public static void InstBonusGo(Transform parentTransform, GameObject[] goToInstatiete)
    {
        //int chance = GetRandomNumberInclusive(0, 10);
        //if (chance != 1) return;

        int randomIdx = GetRandomNumberInclusive(0, goToInstatiete.Length - 1);
        Instantiate(goToInstatiete[randomIdx], parentTransform.position, Quaternion.identity);
    }

    public static bool IsDoubleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked++;
            if (clicked == 1) clicktime = Time.time;
        }
        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            return true;
        }
        else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
        return false;
    }

    public static Vector2 GetScreenBounds()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public static int GetRandomNumberInclusive(int from, int to)
    {
        return UnityEngine.Random.Range(from, to + 1); //Because is exlusive we add +1
    }

    public static Vector3 GetRotation()
    {
        int rotationNumber = UnityEngine.Random.Range(0, 2); //[inclusive] , [exclusive] 0 - 1 in this example;
        return rotationNumber == 0 ? Vector3.forward : Vector3.back;
    }

    public static void RotateGameObject(GameObject go, Vector3 rotation, float rotationSpeed)
    {
        go.transform.Rotate(rotation * rotationSpeed);
    }

    public static void CheckDestroyGameObject(GameObject go)
    {
        if (go.transform.position.x > 0)
        {
            if (go.transform.position.x > screenBounds.x + C_SCREEN_OFFSET)
            {
                Destroy(go);
                return;
            }
        }
        else if (go.transform.position.x < 0)
        {
            if (go.transform.position.x < -screenBounds.x - C_SCREEN_OFFSET)
            {
                Destroy(go);
                return;
            }
        }

        if (go.transform.position.y > 0)
        {
            if (go.transform.position.y > screenBounds.y + C_SCREEN_OFFSET)
            {
                Destroy(go);
                return;
            }
        }
        else if (go.transform.position.y < 0)
        {
            if (go.transform.position.y < -screenBounds.y - C_SCREEN_OFFSET)
            {
                Destroy(go);
                return;
            }
        }
    }

    public static bool CollisionWithBonus(Collider2D collision)
    {
        return collision.gameObject.tag == "Bonus";
    }

    public static bool CollisionWithBonus(Collision2D collision)
    {
        return collision.gameObject.tag == "Bonus";
    }

    public static bool CollisionWithEnemy(Collider2D collision)
    {
        return collision.gameObject.tag == "Enemy";
    }

    public static bool CollisionWithEnemy(Collision2D collision)
    {
        return collision.gameObject.tag == "Enemy";
    }

    public static bool CollisionWithShield(Collider2D collision)
    {
        return collision.gameObject.tag == "Shield";
    }

    public static bool CollisionWithShield(Collision2D collision)
    {
        return collision.gameObject.tag == "Shield";
    }

    public static bool CollisionWithBullet(Collider2D collision)
    {
        return collision.gameObject.tag == "Bullet";
    }

    public static bool CollisionWithBullet(Collision2D collision)
    {
        return collision.gameObject.tag == "Bullet";
    }

    public static bool CollisionWithEarth(Collider2D collision)
    {
        return collision.gameObject.tag == "Earth";
    }

    public static bool CollisionWithEarth(Collision2D collision)
    {
        return collision.gameObject.tag == "Earth";
    }

    public static bool CollisionWithSpaceship(Collider2D collision)
    {
        return collision.gameObject.name == "spaceship";
    }

    public static bool CollisionWithSpaceship(Collision2D collision)
    {
        return collision.gameObject.name == "spaceship";
    }
}
