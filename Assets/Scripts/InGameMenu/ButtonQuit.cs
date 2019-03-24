using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonQuit : MonoBehaviour
{
    public MusicManager musicManager = null;
    private Music music = null;
    // Start is called before the first frame update
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (musicManager != null)
            music = musicManager.getMusic(musicManager.PlayingMusic());
        print("ButtonQuit created");
    }
    public void OnClick()
    {
        print("Unloading menu, quitting game...");
        music.MusicReset();
        SceneManager.LoadScene("Menu");
    }
}
