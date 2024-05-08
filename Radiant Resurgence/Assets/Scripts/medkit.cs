using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkit : MonoBehaviour
{
    [SerializeField] AudioSource healSFX;
    [SerializeField] private Character character;
    void OnCollisionEnter2D(Collision2D collision)
    {
        //logic for character and mutant collision
        if (collision.gameObject.CompareTag("Character")){
            if (character != null){
                character.Heal();
                healSFX.Play();
                Destroy(gameObject);
            }
        }
    }
}
