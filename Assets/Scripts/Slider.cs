using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    private float timeLeft = 0.1F;
    private const string keyBoardEntries = "ZERTYUIO";
    private GameObject[] noteSlider = null;
    
    
    // Start is called before the first frame update
    private void Start()
    {
       /* if (noteSlider == null)
        {
            noteSlider = GameObject.FindGameObjectsWithTag("noteSlider");
            foreach (GameObject slider in noteSlider)
            {
                slider.transform.localScale = new Vector3(0.05F, 10, 0.05F);
            }
        }*/
    }

    // Update is called once per frame
    private void Update()
    {
        //Reset de la size du slider après TimeLeft
        timeLeft -= Time.deltaTime;
        /*if (timeLeft <= 0)
        {
            foreach (GameObject slider in noteSlider)
            {
                slider.transform.localScale = new Vector3(0.05F, 10, 0.05F);
            }
            timeLeft = 0.1F;
        }*/
    }

}
