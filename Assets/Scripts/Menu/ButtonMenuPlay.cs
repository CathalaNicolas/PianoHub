using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenuPlay : MonoBehaviour
{
    public MusicManager manager = null;

    public void Play()
    {
        manager = GameObject.FindWithTag("MusicManager").GetComponent<MusicManager>();
        Music music1 = GameObject.FindWithTag("Music").GetComponent<Music>();
        if (music1 != null)
        {
        music1.AddNote(24, 1, 1);
        music1.AddNote(24, 2, 1);
        music1.AddNote(24, 3, 1);
        music1.AddNote(25, 4, 1);
        music1.AddNote(26, 5, 2);
        music1.AddNote(25, 7, 2);
        music1.AddNote(24, 9, 1);
        music1.AddNote(26, 10, 1);
        music1.AddNote(25, 11, 1);
        music1.AddNote(25, 12, 1);
        music1.AddNote(24, 13, 2);
        music1.AddNote(24, 15, 1);
        music1.AddNote(24, 16, 1);
        music1.AddNote(24, 17, 1);
        music1.AddNote(25, 18, 1);
        music1.AddNote(26, 19, 2);
        music1.AddNote(25, 21, 2);
        music1.AddNote(24, 23, 1);
        music1.AddNote(26, 24, 1);
        music1.AddNote(25, 25, 1);
        music1.AddNote(25, 26, 1);
        music1.AddNote(24, 27, 2);
        music1.AddNote(25, 29, 1);
        music1.AddNote(25, 30, 1);
        music1.AddNote(25, 31, 1);
        music1.AddNote(25, 32, 1);
        music1.AddNote(22, 33, 2);
        music1.AddNote(22, 35, 2);
        music1.AddNote(25, 36, 1);
        music1.AddNote(24, 37, 1);
        music1.AddNote(23, 38, 1);
        music1.AddNote(22, 39, 1);
        music1.AddNote(21, 40, 2);
        music1.AddNote(24, 42, 1);
        music1.AddNote(24, 43, 1);
        music1.AddNote(24, 44, 1);
        music1.AddNote(25, 45, 1);
        music1.AddNote(26, 47, 2);
        music1.AddNote(25, 49, 2);
        music1.AddNote(24, 51, 1);
        music1.AddNote(26, 52, 1);
        music1.AddNote(25, 53, 1);
        music1.AddNote(25, 54, 1);
        music1.AddNote(24, 55, 2);
        //ajouter les note
        manager.addMusic(music1);

        }
       SceneManager.LoadScene("Game");
    }
}
