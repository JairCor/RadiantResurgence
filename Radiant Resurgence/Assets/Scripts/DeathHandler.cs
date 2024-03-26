using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathHandler : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    public void HandleDeath()
    {
        Time.timeScale = 0;
        deathScreen.SetActive(true);
        Debug.Log("Character has died. Death screen should appear.");
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
