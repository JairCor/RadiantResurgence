using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] Image image;
    public void Play()
    {
        StartCoroutine(WaitAndLoadScene(0.3f, "Game"));
    }
    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoadScene(float seconds, string sceneName)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName);

    }
}
