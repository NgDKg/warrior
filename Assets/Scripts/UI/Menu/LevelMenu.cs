using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    //public Button[] buttons;

    //// add rule to game: player can only play next level after playing precious level 
    //private void Awake()
    //{
    //    int unlockedLevel = PlayerPrefs.GetInt("unlockedLevel", 1);

    //    for (int i = 0; i < buttons.Length; i++)
    //    {
    //        buttons[i].interactable = false;
    //    }

    //    for (int i = 0; i < unlockedLevel; i++)
    //    {
    //        buttons[i].interactable = true;
    //    }
        
    //}

    // set to level buttons
    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId;
        SceneManager.LoadSceneAsync(levelName);
    }
}
