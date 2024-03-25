using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    public void HandleDeath()
    {
        deathScreen.SetActive(true);
        Debug.Log("Character has died. Death screen should appear.");
    }
}
