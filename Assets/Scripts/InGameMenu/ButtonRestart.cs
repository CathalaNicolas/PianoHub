using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRestart : MonoBehaviour
{
    public MusicManager musicManager = null;
    private Music music;
    // Start is called before the first frame update
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (musicManager != null)
            music = musicManager.getMusic(musicManager.PlayingMusic());
        print("ButtonRestart created");
    }
    public void OnClick()
    {
        print("Unloading menu, restarting game...");
        music.MusicReset();
        music.start = true;
        SceneManager.LoadScene("Game");
    }
}
