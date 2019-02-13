using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
     public MusicLoader Loader;
     public List<Music> listMusic = new List<Music>();
     private int nbMusic = 0;
    private  int playingMusic = -1;

     Scene  currentScene;

    public void Start()
    {
/*
        if (currentScene.name == "OpenMusic")
        {
            Loader = GameObject.FindWithTag("MusicLoader").GetComponent<MusicLoader>();
        }*/
        Debug.Log("public manager started !");
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void OnDestroy()
    {
        print("Destroying MusicManager");
    }

    public void LoadMusic(string Path)
    {
        if (Loader != null)
        {
            Debug.Log("loading music");
            Music music = Loader.LoadMusicFromPath(Path);
            if (music == null)
                print("Can't Load music = null");
            else
            {

                listMusic.Add(music);
                nbMusic += 1;
            }
        }
        else
            Debug.Log("Loader not attached");
    }
    public void addMusic(Music music)
    {
        listMusic.Add(music);
    }

    public void PlayMusic(int nb)
    {

        if (nb <= nbMusic && nb >= 0)
        {
            print("Found music starting it...");
            listMusic[nb].start = true;
            playingMusic = nb;
        }
    }

    public  Music getMusic(int nb)
    {
        if (nb <= nbMusic && nb >= 0)
        {
            return (listMusic[nb]);
        }
        return (null);
    }
 
    public  int PlayingMusic()
    {
        return (playingMusic);
    }

    public void UnloadMusic(Music music)
    {
        listMusic.Remove(music);
    }

    public void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Game")
        {
            PlayMusic(0);
        }
    }
}
