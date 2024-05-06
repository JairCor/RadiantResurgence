using UnityEngine;
using System.Collections;

public class AR15 : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform upBulletSpawnPoint;
    [SerializeField] private Transform downBulletSpawnPoint;
    [SerializeField] private Transform rightBulletSpawnPoint;
    [SerializeField] private Transform leftBulletSpawnPoint;

    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float bulletLifetime = 1f; // Lifetime of the bullet
    [SerializeField] private GameObject flashPrefab; // Add a reference to the flash effect prefab
    [SerializeField] private AudioSource gunshotAudio; // Add a reference to the gunshot audio source
    
    // Reference to the character's sprite renderer
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite upSprite;
    [SerializeField] public Sprite downSprite;
    [SerializeField] public Sprite leftSprite;
    [SerializeField] public Sprite rightSprite;

    // Update is called once per frame
    void Update()
    {
        // Check for shooting input
        if (Input.GetMouseButtonDown(0)) // Change this condition to match your shooting input
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        // Determine bullet spawn point based on character's orientation
        if (spriteRenderer.sprite == leftSprite)
        {
            ShootBullet(leftBulletSpawnPoint);
        }
        else if (spriteRenderer.sprite == rightSprite)
        {
            ShootBullet(rightBulletSpawnPoint);
        }
        else if (spriteRenderer.sprite == downSprite)
        {
            ShootBullet(downBulletSpawnPoint);
        }
        else // Assume up orientation by default
        {
            ShootBullet(upBulletSpawnPoint);
        }
    }

    private void ShootBullet(Transform spawnPoint)
    {
        // Instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

        // Calculate direction based on character's orientation
        Vector2 bulletDirection = Vector2.zero;

        if (spriteRenderer.sprite == leftSprite)
        {
            bulletDirection = -spawnPoint.right; // Bullet moves left
            bullet.transform.rotation = Quaternion.FromToRotation(Vector2.left, bulletDirection); // Rotate bullet accordingly
        }
        else if (spriteRenderer.sprite == rightSprite)
        {
            bulletDirection = spawnPoint.right; // Bullet moves right
            bullet.transform.rotation = Quaternion.FromToRotation(Vector2.right, bulletDirection); // Rotate bullet accordingly
        }
        else if (spriteRenderer.sprite == downSprite)
        {
            bulletDirection = -spawnPoint.up; // Bullet moves down
            bullet.transform.rotation = Quaternion.FromToRotation(Vector2.down, bulletDirection); // Rotate bullet accordingly
        }
        else // Assume up orientation by default
        {
            bulletDirection = spawnPoint.up; // Bullet moves up
            bullet.transform.rotation = Quaternion.FromToRotation(Vector2.up, bulletDirection); // Rotate bullet accordingly
        }

        // Apply velocity to bullet
        bulletRB.velocity = bulletDirection * bulletSpeed;

        // Start the flash effect coroutine if the character is not pointing up
        if (spriteRenderer.sprite != upSprite)
        {
            StartCoroutine(FlashEffect(spawnPoint));
        }

        // Destroy bullet after its lifetime
        Destroy(bullet, bulletLifetime);

        // Play gunshot audio
        gunshotAudio.Play();
    }




    // Coroutine for flash effect
    private IEnumerator FlashEffect(Transform spawnPoint)
    {
        // Instantiate flash effect
        GameObject flash = Instantiate(flashPrefab, spawnPoint.position, spawnPoint.rotation);

        // Wait for half a second
        yield return new WaitForSeconds(0.01f);

        // Destroy the flash effect
        Destroy(flash);
    }
}
