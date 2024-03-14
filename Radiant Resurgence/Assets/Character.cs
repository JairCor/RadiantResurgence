using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [Header("Stats")]

    [Header("Positional Data")]
    [SerializeField] Vector3 homePosition = Vector3.zero;
    [SerializeField] private GameObject body;
    [SerializeField] private float speed = 7;
    Rigidbody2D rb;

    [Header("Audio")]
    AudioSource gunShotAudio;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
            body.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rb.velocity.x > 0)
        {
            body.transform.localScale = new Vector3(1, 1, 1);
            }
    }
}
