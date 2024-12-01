using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // set to the play button
    // click play button to start level 1
    //public void Play()
    //{
    //    SceneManager.LoadSceneAsync(1);
    //}

    // set to quit button
    public void Quit()
    {
        Application.Quit();
    }
}
