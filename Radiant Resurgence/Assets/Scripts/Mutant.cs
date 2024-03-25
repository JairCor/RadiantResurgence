using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mutant : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float health = 100f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float speed = 7f;


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
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on Walker child GameObject.");
        }
    }
    void Start()
    {
        homePosition = transform.position; 
    } 
    public void MoveMutant(Vector3 direction){
        direction = direction.normalized;
        rb.velocity = direction * speed;

        float horizontalMovement = Mathf.Abs(rb.velocity.x);
        float verticalMovement = Mathf.Abs(rb.velocity.y);

        // Finding dominant movement, then changing sprites accordingly
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

}
