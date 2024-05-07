using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsPage;

    [SerializeField] Image image;

    void Start()
    {
        mainMenu.SetActive(true);
        settingsPage.SetActive(false);
    }

    public void Play()
    {
        loadingText.text = "LOADING...";
        StartCoroutine(WaitAndLoadScene(0.3f, "Game"));
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        settingsPage.SetActive(true);
    }

    public void GoBackToMainMenu()
    {
        settingsPage.SetActive(false);
        mainMenu.SetActive(true);
    }


    IEnumerator WaitAndLoadScene(float seconds, string sceneName)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName);

    }
}
