using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenuPlay : MonoBehaviour
{
    public MusicManager manager = null;
    public GameObject Piano;
    public GameObject Button;

    public void Play()
    {
        Piano = GameObject.FindGameObjectWithTag("Piano");
        Button = GameObject.Find("Play");
        Button.transform.position = new Vector3(Piano.transform.position.x -0.2f, Piano.transform.position.y + 0.4f, Piano.transform.position.z);
        SceneManager.LoadScene("Game");
    }


}
