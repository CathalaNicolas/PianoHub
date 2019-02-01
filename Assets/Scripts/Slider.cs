using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    private const float scaleX = 0.1F;
    private const float scaleY = 10;
    private const float scaleZ = 0.1F;
    private float timeLeft = 0.1F;
    private const string keyBoardEntries = "ZERTYUIO";
    private GameObject[] noteSlider = null;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        if (noteSlider == null)
        {
            noteSlider = GameObject.FindGameObjectsWithTag("noteSlider");
            foreach (GameObject slider in noteSlider)
            {
                slider.transform.localScale = new Vector3(0.05F, 10, 0.05F);
            }
            setNoteSliderPosition();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                if (noteSlider != null && keyBoardEntries.Contains(vKey.ToString()) == true)
                {
                    noteSlider[(keyBoardEntries.Length - 1) - keyBoardEntries.IndexOf(vKey.ToString())].transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                }
            }
        }
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            foreach (GameObject slider in noteSlider)
            {
                slider.transform.localScale = new Vector3(0.05F, 10, 0.05F);
            }
            timeLeft = 0.1F;
        }
    }
    private int compareNoteSlider(GameObject slider, GameObject slider2)
    {
        char name1 = slider.name[slider.name.Length - 2];
        char name2 = slider2.name[slider2.name.Length - 2];
        
        if (keyBoardEntries.IndexOf(name1) < keyBoardEntries.IndexOf(name2))
            return 1;
        return 0;
    }
    private void setNoteSliderPosition()
    {
        bool sorted = false;
        GameObject  tmp;

        while (sorted == false)
        {
            sorted = true;
            for (int i = 0; i < noteSlider.Length - 1; i++)
            {
                if (i + 1 < noteSlider.Length && compareNoteSlider(noteSlider[i], noteSlider[i + 1]) > 0)
                {
                    tmp = noteSlider[i];
                    noteSlider[i] = noteSlider[i + 1];
                    noteSlider[i + 1] = tmp;
                    sorted = false;
                }
            }
        }
 
    }
}
