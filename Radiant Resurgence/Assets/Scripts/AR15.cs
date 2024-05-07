using UnityEngine;
using System.Collections;

public class AR15 : MonoBehaviour
{
    [Header("Shooting")]
    // Bullet spawn points depending on orientation of character
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform upBulletSpawnPoint;
    [SerializeField] private Transform downBulletSpawnPoint;
    [SerializeField] private Transform rightBulletSpawnPoint;
    [SerializeField] private Transform leftBulletSpawnPoint;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float bulletLifetime = 1f;
    [SerializeField] private GameObject flashPrefab;
    [SerializeField] private AudioSource gunshotAudio;
    
    // Reference to the character's sprites for orientation
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite upSprite;
    [SerializeField] public Sprite downSprite;
    [SerializeField] public Sprite leftSprite;
    [SerializeField] public Sprite rightSprite;

    void Update()
    {
    }

    public void Shoot()
    {
        // Checking what direction the character is facing 
        if (spriteRenderer.sprite == leftSprite){
            ShootBullet(leftBulletSpawnPoint);
        }
        else if (spriteRenderer.sprite == rightSprite){
            ShootBullet(rightBulletSpawnPoint);
        }
        else if (spriteRenderer.sprite == downSprite){
            ShootBullet(downBulletSpawnPoint);
        }
        else { //Default orientation just in case
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

        if (spriteRenderer.sprite == leftSprite){
            bulletDirection = -spawnPoint.right; // Bullet goes left
            bullet.transform.rotation = Quaternion.FromToRotation(Vector2.left, bulletDirection); // Rotate bullet sprite to the left
        }
        else if (spriteRenderer.sprite == rightSprite){
            bulletDirection = spawnPoint.right; // Bullet goes right
            bullet.transform.rotation = Quaternion.FromToRotation(Vector2.right, bulletDirection); // Rotate bullet to the right
        }
        else if (spriteRenderer.sprite == downSprite){
            bulletDirection = -spawnPoint.up; // Bullet goes down
            bullet.transform.rotation = Quaternion.FromToRotation(Vector2.down, bulletDirection); // Rotate down
        }
        else { // Assume up orientation by default
            bulletDirection = spawnPoint.up; // Bullet goes up
            bullet.transform.rotation = Quaternion.FromToRotation(Vector2.up, bulletDirection); // Rotate up
        }

        // Applying the speed of the bullet
        bulletRB.velocity = bulletDirection * bulletSpeed;


        //Starting the flash effect, unless the character is facing up
        if (spriteRenderer.sprite != upSprite)
        {
            StartCoroutine(FlashEffect(spawnPoint));
        }

        //Destroying the bullet to prevent overload of objects
        if(bullet != null){
            Destroy(bullet, bulletLifetime);
        }


        // Playing gun audio
        gunshotAudio.Play();
    }

    private IEnumerator FlashEffect(Transform spawnPoint)
    {
        // Instantiate flash image
        GameObject flash = Instantiate(flashPrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(0.01f);
        Destroy(flash);
    }
}

