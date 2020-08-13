using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using System;

public class Spaceship : MonoBehaviour
{
    private const string BONUS_FIRE_POINT = "BonusFirePointBar";
    private const string BONUS_FIRE_BULLET = "BonusFireShootingtBar";

    private const float X = -5f;
    private const float Y = -25f;
    private const float Y_DIFF = -75f;

    [SerializeField] private GameObject canvas = default;

    [SerializeField] private GameObject bonusFirePointBar = default;
    [SerializeField] private GameObject bonusFireShootingBar = default;

    [SerializeField] private GameObject fireShield = default;
    [SerializeField] private GameObject shipExplosion = default;
    [SerializeField] private float destroyExplosionAfter = 2f;

    [SerializeField] private Button shieldButton;
    [SerializeField] private BulletsSpawner bulletsSpawner;
    [SerializeField] private BulletController bulletController = default;

    public bool fireShieldIsActive;
    private AudioSource bonusAudio;

    private GameObject onGoingBar = default;
    private GameObject secondOnGoingBar = default;

    private bool isCenterBulletRunning;
    private bool isFireBulletRunning;

    private float defaultTimeBetweenShooting;
    private float fastTimeBetweenShooting = 0.1f;

    private void Start()
    {
        isCenterBulletRunning = false;
        isFireBulletRunning = false;

        defaultTimeBetweenShooting = bulletController.TimeBetweenShooting;

        fireShield.SetActive(false);
        fireShieldIsActive = false;

        bonusAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CheckBarsAreRunning();
        CheckReturnToDefault();
    }

    private void CheckBarsAreRunning()
    {
        isFireBulletRunning = false;
        isCenterBulletRunning = false;

        if (onGoingBar == null && secondOnGoingBar == null)
        {
            return;
        }

        if (onGoingBar != null)
        {
            if (onGoingBar.name.StartsWith(BONUS_FIRE_BULLET))
            {
                isFireBulletRunning = true;
            }
            else if (onGoingBar.name.StartsWith(BONUS_FIRE_POINT))
            {
                isCenterBulletRunning = true;
            }
        }

        if (secondOnGoingBar != null)
        {
            if (secondOnGoingBar.name.StartsWith(BONUS_FIRE_POINT))
            {
                isCenterBulletRunning = true;
            }
            else if (secondOnGoingBar.name.StartsWith(BONUS_FIRE_BULLET))
            {
                isFireBulletRunning = true;
            }
        }
    }

    private void SetSpaceshipDefaultBullet()
    {
        bulletController.ChangeBullet(0);
        bulletController.TimeBetweenShooting = defaultTimeBetweenShooting;
    }

    private void SetSpashipDefaultFirePoints()
    {
        bulletController.StopCenterFirePoint();
    }

    public void ChangeShieldState()
    {
        if (GameController.currentShieldPoints <= 0) return;

        fireShieldIsActive = !fireShieldIsActive;
        fireShield.SetActive(fireShieldIsActive);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CollisionWithEnemy(collision))
        {
            if (!fireShieldIsActive)
                GameController.AddRemoveHealth(-1);
        }
        else if (Utils.CollisionWithBonus(collision))
        {
            if (collision.gameObject.name.StartsWith("BonusFirePoint"))
            {
                bulletController.ActiveCenterFirePoint();

                SetBonusBar(bonusFirePointBar);
            }
            else if (collision.gameObject.name.StartsWith("BonusFireShooting"))
            {
                bulletController.ChangeBullet(1);
                bulletController.TimeBetweenShooting = fastTimeBetweenShooting;

                SetBonusBar(bonusFireShootingBar);
            }

            bonusAudio.Play();
        }
    }

    private void CheckReturnToDefault()
    {
        if (!isFireBulletRunning)
        {
            SetSpaceshipDefaultBullet();
        }

        if (!isCenterBulletRunning)
        {
            SetSpashipDefaultFirePoints();
        }
    }

    private void SetBonusBar(GameObject bar)
    {
        if (onGoingBar == null)
        {
            onGoingBar = ActiveBonusBar(bar, new Vector2(X, Y));
        }
        else if (onGoingBar.name.StartsWith(bar.name))
        {
            ManaBar manaBarScript = onGoingBar.GetComponent<ManaBar>();
            manaBarScript.RestoreMana();
        }
        else if (secondOnGoingBar == null)
        {
            secondOnGoingBar = ActiveBonusBar(bar, new Vector2(X, Y + Y_DIFF));
        }
        else if (secondOnGoingBar.name.StartsWith(bar.name))
        {
            ManaBar manaBarScript = secondOnGoingBar.GetComponent<ManaBar>();
            manaBarScript.RestoreMana();
        }
    }

    private GameObject ActiveBonusBar(GameObject bar, Vector2 position)
    {
        GameObject go = Instantiate(bar, position, Quaternion.identity);
        Transform bonusPanel = canvas.transform.Find("Panel_Bonus");

        go.transform.SetParent(bonusPanel, false);

        return go;
    }

    private void DestroySpaceShip()
    {
        Destroy(this.gameObject);
        GameObject explosionGameObject = Instantiate(shipExplosion, transform.position, Quaternion.identity);
        Destroy(explosionGameObject, destroyExplosionAfter);
    }
}
