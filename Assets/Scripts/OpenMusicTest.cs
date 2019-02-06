using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMusicTest : MonoBehaviour
{
    string path;
    MusicManager musicManager;

    public void Start()
    {
        musicManager = this.gameObject.AddComponent(typeof(MusicManager)) as MusicManager;
    }

    public void OpenExplorer()
    {
        path = EditorUtility.OpenFilePanel("Music Loader", "", "txt");
        musicManager.LoadMusic(path);
        SceneManager.LoadScene("Game");
    }

}
