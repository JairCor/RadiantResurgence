using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    //references to scripts
    [SerializeField] Character character;
    [SerializeField] AR15 ar15;
    [SerializeField] private GameObject pausedText; 
    [SerializeField] private GameObject menuButton;


    // Update is called once per frame
    void Update()
    {
        Vector3 input = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Escape)){
            TogglePause();
        }
        if(Time.timeScale == 0f){
            AudioListener.pause = true;
            pausedText.SetActive(true);
            menuButton.SetActive(true);
            return; 
        }
        else{
            AudioListener.pause = false;
            pausedText.SetActive(false);
            menuButton.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))                     
            ar15.Shoot();
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

    void TogglePause()
    {
        if (Time.timeScale == 0f){
            Time.timeScale = 1f;
        }
        else{
            Time.timeScale = 0f;
        }
    }
    
}
