using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("gra");
    }

    public void Settings()
    {
        SceneManager.LoadScene("settingsv2");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
