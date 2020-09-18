using UnityEngine;
using UnityEngine.EventSystems;

public class BulletsSpawner : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject spaceship = default;
    [SerializeField] private GameObject fireShield = default;
    [SerializeField] private GameObject[] firePoints = default;

    [SerializeField] private BulletController bulletController = default;

    [SerializeField] private float parentKick = 0.1f;

    Vector2 screenBounds;

    GameObject parentGameObject = default;

    private AudioSource shootingSound = default;
    private float nextShoot = 0f;
    private bool shieldIsActive;
    private bool pointerDown;

    private void Start()
    {
        shootingSound = GetComponent<AudioSource>();
        parentGameObject = this.transform.parent.gameObject;
        screenBounds = Utils.GetScreenBounds();
    }

    // Update is called once per frame
    void Update()
    {
        if (pointerDown)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (CheckShieldIsActive()) return;

        if (nextShoot <= Time.time)
        {
            SpawnBullets();
            nextShoot = Time.time + bulletController.TimeBetweenShooting;
            shootingSound.Play();
        }
    }

    private void SpawnBullets()
    {
        SpawnBullet();

        KickSpaceshipBack();
    }

    private void SpawnBullet()
    {
        for (int idx = 0; idx < firePoints.Length; idx++)
        {
            GameObject currentFirePoint = firePoints[idx];

            if (!currentFirePoint.activeSelf) continue;

            Instantiate(bulletController.GetBullet(), currentFirePoint.transform);
        }
    }

    private bool CheckShieldIsActive()
    {
        return fireShield.activeSelf;
    }

    private void KickSpaceshipBack()
    {
        float kickNewPosY = spaceship.transform.position.y - parentKick;

        if (kickNewPosY < -screenBounds.y)
            kickNewPosY = -screenBounds.y;

        spaceship.transform.position = new Vector2(spaceship.transform.position.x, kickNewPosY);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }
}
