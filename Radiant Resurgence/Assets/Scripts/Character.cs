using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float stamina = 100f;
    private float currentHealth;
    private float originalSpeed;

    [Header("Positional Data")]
    [SerializeField] Vector3 homePosition = Vector3.zero;
    [SerializeField] private GameObject body;
    Rigidbody2D rb;


    [Header("Flavor")]
    [SerializeField] public string name = "Classified";
    [SerializeField] public Sprite upSprite;
    [SerializeField] public Sprite downSprite;
    [SerializeField] public Sprite leftSprite;
    [SerializeField] public Sprite rightSprite;
    [SerializeField] private float ar15OffsetX = 0.1f;
    [SerializeField] private AudioSource damageSFX;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer ar15Renderer;
    
    
    [Header("Red Flash")]
    [SerializeField] private float flashDuration = 0.2f;
    private Color originalColor;

    [SerializeField] DeathHandler deathHandler;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = transform.Find("Body").GetComponent<SpriteRenderer>();
        ar15Renderer = transform.Find("ar15").GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    void Start()
    {   //setting home position where i left it on the scene
        homePosition = transform.position; 
        currentHealth = maxHealth;
        originalSpeed = speed;
    } 

    public void MoveCharacter(Vector3 direction)
    {
        direction = direction.normalized;
        rb.velocity = direction * speed;

        // Flip sprite based on movement direction
        if (rb.velocity.x < 0)
        {
            ar15Renderer.enabled = true;
            spriteRenderer.sprite = leftSprite;
            ar15Renderer.flipX = true;
            ar15Renderer.transform.localPosition = new Vector3(-ar15OffsetX, ar15Renderer.transform.localPosition.y, ar15Renderer.transform.localPosition.z);
        }
        else if (rb.velocity.x > 0)
        {
            ar15Renderer.enabled = true;
            spriteRenderer.sprite = rightSprite;
            ar15Renderer.flipX = false;
            ar15Renderer.transform.localPosition = new Vector3(ar15OffsetX, ar15Renderer.transform.localPosition.y, ar15Renderer.transform.localPosition.z);
        }
        else if(rb.velocity.y < 0)
        {
            ar15Renderer.enabled = false;
            spriteRenderer.sprite = downSprite;
        }
        else if(rb.velocity.y > 0)
        {
            ar15Renderer.enabled = false;
            spriteRenderer.sprite = upSprite;
        }
    }
    public void StartSprint()
    {
        speed = originalSpeed * 1.5f;
    }
    public void EndSprint()
    {
        speed = originalSpeed;
    }
    





    public void Shoot()
    {
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        damageSFX.Play();
        StartCoroutine(FlashRed());
        Debug.Log(currentHealth);
        if (currentHealth <= 0){
            Die();
        }
    }

    public IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    void Die()
    {
        deathHandler.HandleDeath();
    }
}
