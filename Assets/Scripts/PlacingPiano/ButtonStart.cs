using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    public GameManager gameManager = null;
    bool alreadyClick = false;

    public void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager == null)
        {
            print("GameManager can't be found.");
            return;
        }
    }

    public void StartGame()
    {
        if (alreadyClick == false)
        {
            alreadyClick = true;
            gameManager.initSliders();
            print("Sliders initialised!");
            SceneManager.LoadScene("Menu");
        }
    }
}
