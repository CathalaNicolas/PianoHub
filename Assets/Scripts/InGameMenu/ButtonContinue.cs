using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonContinue : MonoBehaviour
{
    public MusicManager musicManager = null;
    private Music music;
    // Start is called before the first frame update
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (musicManager != null)
            music = musicManager.getMusic(musicManager.PlayingMusic());
        print("ButtonContinue created");
    }

    public void OnClick()
    {
        print("Unloading menu, continuing game...");

        music.timePausedEnd = Time.time;
        music.start = true;
        SceneManager.LoadSceneAsync("Game");
    }
}
