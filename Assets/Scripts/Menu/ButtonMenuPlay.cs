using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenuPlay : MonoBehaviour
{
    public GameManager gameManager = null;

    public void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager == null)
        {
            print("GameManager can't be found.");
            return;
        }
    }

    public void Play()
    {
       SceneManager.LoadScene("PlayMenu");
    }
}
