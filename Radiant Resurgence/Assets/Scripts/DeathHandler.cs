using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathHandler : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject playerInput;
    public void HandleDeath()
    {
        Time.timeScale = 0;
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
}
