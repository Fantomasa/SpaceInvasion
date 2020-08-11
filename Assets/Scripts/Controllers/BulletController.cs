using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject centerFirePoint = default;
    [SerializeField] private GameObject[] bullets = default;

    private float timeBetweenShooting = 0.3f;

    private int bulletIdx;

    public GameObject GetBullet()
    {
        return bullets[bulletIdx];
    }

    public void ChangeBullet(int newBulletIdx)
    {
        bulletIdx = newBulletIdx;
        if (bulletIdx > bullets.Length) bulletIdx = bullets.Length;
    }

    public float TimeBetweenShooting
    {
        get
        {
            return timeBetweenShooting;
        }
        set
        {
            if (value > 0)
            {
                timeBetweenShooting = value;
            }
        }
    }

    public void ActiveCenterFirePoint()
    {
        centerFirePoint.SetActive(true);
    }
}
