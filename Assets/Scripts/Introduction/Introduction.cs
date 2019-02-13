using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{
    public float WaitingTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= WaitingTime)
        {
            SceneManager.LoadScene("placingPiano");
        }
    }
}
