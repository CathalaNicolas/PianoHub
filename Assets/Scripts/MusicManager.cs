using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    MusicLoader Loader;

    public void Start()
    {
        Loader = new MusicLoader();
    }

    public void LoadMusic(string Path)
    {
        Music music = Loader.LoadMusicFromPath(Path);
    }

    public void UnloadMusic(Music music)
    {
        Destroy(music);
    }
}
