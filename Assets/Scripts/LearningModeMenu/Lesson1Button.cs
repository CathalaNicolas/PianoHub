using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lesson1Button : MonoBehaviour
{
    public MusicManager manager = null;

    public void Lesson1()
    {
        SceneManager.LoadScene("Lesson1");
    }
}
