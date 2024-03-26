using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function to load the "Play" scene
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    // Function to load the "Options" scene
    public void OpenOptions()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    // Function to exit the application
    public void ExitGame()
    {
        Application.Quit();
    }
}
