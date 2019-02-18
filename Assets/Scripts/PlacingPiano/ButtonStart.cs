using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    public GameManager gameManager = null;
    public GameObject Piano;
    public GameObject Button;

    public void Start()
    {
        Piano = GameObject.FindGameObjectWithTag("Piano");
        Button = GameObject.Find("Button");
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager == null)
        {
            print("GameManager can't be found.");
            return;
        }
    }

    public void StartGame()
    {
        gameManager.initSliders();
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        Button.transform.position = new Vector3(Piano.transform.position.x, Piano.transform.position.y + 0.2f, Piano.transform.position.z);
    }
}
