using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float health = 100f;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float stamina = 100f;

    [Header("Positional Data")]
    [SerializeField] Vector3 homePosition = Vector3.zero;
    [SerializeField] private GameObject body;
    Rigidbody2D rb;

    [Header("Audio")]
    AudioSource gunShotAudio;

    [Header("Flavor")]
    [SerializeField] public string name = "Layton";
    [SerializeField] public Sprite upSprite;
    [SerializeField] public Sprite downSprite;
    [SerializeField] public Sprite leftSprite;
    [SerializeField] public Sprite rightSprite;
    private SpriteRenderer spriteRenderer;
    
    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletSpeed = 10f;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = transform.Find("Body").GetComponent<SpriteRenderer>();
    }
    void Start()
    {   //setting home position where i left it on the scene
        homePosition = transform.position; 
    } 

    public void MoveCharacter(Vector3 direction)
    {

        direction = direction.normalized;
        rb.velocity = direction * speed;

        // Flip sprite based on movement direction
        if (rb.velocity.x < 0)
        {
            spriteRenderer.sprite = leftSprite;
        }
        else if (rb.velocity.x > 0)
        {
            spriteRenderer.sprite = rightSprite;
        }
        else if(rb.velocity.y < 0)
        {
            spriteRenderer.sprite = downSprite;
        }
        else if(rb.velocity.y > 0)
        {
            spriteRenderer.sprite = upSprite;
        }
    }
    
    public void Shoot()
    {
    }
}