using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuReturnButton : MonoBehaviour
{
    public MusicManager manager = null;

    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }
}