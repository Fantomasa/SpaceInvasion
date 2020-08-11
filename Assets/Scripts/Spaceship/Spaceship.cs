using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private GameObject fireShield = default;
    [SerializeField] private GameObject shipExplosion = default;
    [SerializeField] private float destroyExplosionAfter = 2f;

    [SerializeField] private Button shieldButton;
    [SerializeField] private BulletsSpawner bulletsSpawner;
    [SerializeField] private BulletController bulletController = default;

    private bool fireShieldIsActive;
    private AudioSource bonusAudio;

    private void Start()
    {
        fireShield.SetActive(false);
        fireShieldIsActive = false;

        bonusAudio = GetComponent<AudioSource>();
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
            }
            else if (collision.gameObject.name.StartsWith("BonusFireShooting"))
            {
                bulletController.ChangeBullet(1);
                bulletController.TimeBetweenShooting = 0.1f;
            }

            bonusAudio.Play();
        }
    }

    private void DestroySpaceShip()
    {
        Destroy(this.gameObject);
        GameObject explosionGameObject = Instantiate(shipExplosion, transform.position, Quaternion.identity);
        Destroy(explosionGameObject, destroyExplosionAfter);
    }
}
