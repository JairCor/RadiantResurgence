using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathHandler : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject playerInput;

    [Header("Audio")]
    [SerializeField] private AudioSource deathSfx;

    public void HandleDeath()
    {
        Time.timeScale = 0;
        deathSfx.Play();
        deathScreen.SetActive(true); //Death screen pop up
        playerInput.SetActive(false); // Blocking input after dying
    }

    public void Awake()
    {
        deathScreen.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit(); //Quit the application completely
    }

    public void Respawn()
    {
        SceneManager.LoadScene("Game"); //reload the game
        Time.timeScale = 1;
        
    }

    public void Menu(){
        playerInput.SetActive(false);
        SceneManager.LoadScene("Main Menu"); //Take you back to the main menu
        Time.timeScale = 1;
    }
}
