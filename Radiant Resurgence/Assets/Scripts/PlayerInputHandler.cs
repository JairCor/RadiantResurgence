using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{

    [SerializeField] Character character;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 input = Vector3.zero;

        if (Input.GetMouseButtonDown(0))                     
            character.Shoot();
        if(Input.GetKey(KeyCode.A))
            input.x += -1;
        if(Input.GetKey(KeyCode.D))
            input.x += 1;
        if(Input.GetKey(KeyCode.W))
            input.y += 1;
        if(Input.GetKey(KeyCode.S))
            input.y += -1;
        if (Input.GetKey(KeyCode.LeftShift))
            character.StartSprint();
        if (!Input.GetKey(KeyCode.LeftShift))
            character.EndSprint();

        character.MoveCharacter(input);
    }
}
