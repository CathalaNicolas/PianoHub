using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LearningModeButton : MonoBehaviour
{
    public MusicManager manager = null;

    public void LearningMode()
    {
        SceneManager.LoadScene("LearningModeMenu");
    }
}