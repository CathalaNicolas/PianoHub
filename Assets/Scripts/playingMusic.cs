using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playingMusic : MonoBehaviour
{
    MusicManager manager = null;
    public bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("MusicManager").GetComponent<MusicManager>();
        if (manager != null)
            print("manager is ok !!!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && started == false)
        {
            print("Got enter key : Starting music :))!");
            manager.PlayMusic(0);
            started = true;
        }
    }
}
