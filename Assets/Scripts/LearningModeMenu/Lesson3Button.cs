using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lesson3Button : MonoBehaviour
{
    public MusicManager manager = null;

    public void Lesson3()
    {
        SceneManager.LoadScene("Lesson3");
    }
}
