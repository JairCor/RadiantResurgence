using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mutant : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float damageCooldown = 1f; // To prevent weird unexpected outcomes where you instantly die
    [SerializeField] private float speed = 7f;
    private float currentHealth;
    private float lastDamageTime;

    [Header("Positional Data")]
    [SerializeField] Vector3 homePosition = Vector3.zero;
    Rigidbody2D rb;

    [Header("Flavor")]
    [SerializeField] public string name = "Walker";
    [SerializeField] public Sprite upSprite;
    [SerializeField] public Sprite downSprite;
    [SerializeField] public Sprite leftSprite;
    [SerializeField] public Sprite rightSprite;
    private SpriteRenderer spriteRenderer;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        homePosition = transform.position; 
        currentHealth = maxHealth;
    } 

    public void MoveMutant(Vector3 direction){
        direction = direction.normalized;
        rb.velocity = direction * speed;

        float horizontalMovement = Mathf.Abs(rb.velocity.x);
        float verticalMovement = Mathf.Abs(rb.velocity.y);

        //Finding dominant movement, then changing sprites accordingly, it was doing weird bugs otherwise
        if (horizontalMovement > verticalMovement)
        {
            if (rb.velocity.x < 0)
                spriteRenderer.sprite = leftSprite;
            else if (rb.velocity.x > 0)
                spriteRenderer.sprite = rightSprite;
        }
        else
        {
            if (rb.velocity.y < 0)
                spriteRenderer.sprite = downSprite;
            else if (rb.velocity.y > 0)
                spriteRenderer.sprite = upSprite;
        }
    }

    public void MoveMutantToward(Vector3 target){
        Vector3 direction = target - transform.position;
        MoveMutant(direction.normalized);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character") && Time.time > lastDamageTime + damageCooldown)
        {
            Character character = collision.gameObject.GetComponent<Character>();
            if (character != null)
            {
                character.TakeDamage(damage);
                StartCoroutine(FlashCharacter(character));
                lastDamageTime = Time.time;
            }
        }
    }

    IEnumerator FlashCharacter(Character character)
    {
        character.FlashRed();
        yield return new WaitForSeconds(0.2f);
    }

}
