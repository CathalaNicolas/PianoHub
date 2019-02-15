using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenuPlay : MonoBehaviour
{
    public MusicManager manager = null;

    public void Play()
    { 
       SceneManager.LoadScene("Game");
    }
}
