using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lesson2Button : MonoBehaviour
{
    public MusicManager manager = null;

    public void Lesson2()
    {
        SceneManager.LoadScene("Lesson2");
    }
}

