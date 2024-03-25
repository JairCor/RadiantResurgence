using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 1.0f;

    public void MoveCharacter(Vector3 direction)
    {
        transform.position += direction * speed;
    }
}
