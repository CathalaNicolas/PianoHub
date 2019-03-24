using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMusicTest : MonoBehaviour
{
    string path;
    public MusicManager musicManager = null;

    public void Start()
    {
        musicManager = GameObject.FindWithTag("MusicManager").GetComponent<MusicManager>();
    }

    public void OpenExplorer()
    {
        if (musicManager != null)
        {
            /* print("loading music file");
             path = EditorUtility.OpenFilePanel("Music Loader", "", "txt");
             musicManager.LoadMusic(path);
             SceneManager.LoadScene("Game");*/
        }
        else
            print("No musicManager attached");
    }

}