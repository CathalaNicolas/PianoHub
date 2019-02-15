using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoLoad : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.initSliders();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
