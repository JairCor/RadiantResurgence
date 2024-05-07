using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathHandler : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject playerInput;
    [SerializeField] private AudioSource deathSfx;
    public void HandleDeath()
    {
        Time.timeScale = 0;
        deathSfx.Play();
        deathScreen.SetActive(true);
        playerInput.SetActive(false);
    }
    public void Awake()
    {
        deathScreen.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Respawn()
    {

        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
        
    }
    public void Menu(){
        playerInput.SetActive(false);
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
}
