using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    [SerializeField] Image onMusicButton;
    [SerializeField] Image offMusicButton;

    private bool muted = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButton();
        AudioListener.pause = muted;
    }

    public void OnPressed()
    {
        if (!muted)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButton();
    }

    public void UpdateButton()
    {
        if (muted)
        {
            onMusicButton.enabled = false;
            offMusicButton.enabled = true;
        }
        else
        {
            onMusicButton.enabled = true;
            offMusicButton.enabled = false;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
