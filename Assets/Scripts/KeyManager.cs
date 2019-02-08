﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    private const float scaleX = 0.1F;
    private const float scaleY = 10;
    private const float scaleZ = 0.1F;
    private GameObject[] noteSlider = null;
    private const string keyBoardEntries = "ZERTYUIO";
    

    // Start is called before the first frame update
    void Start()
    {
        print("AH OUUIIIIIIIIIIIII");
        noteSlider = GameObject.FindGameObjectsWithTag("noteSlider");
        if (noteSlider == null)
            print("NONNNNNN");
        SortNoteSliderPosition();
    }

    private void OnDestroy()
    {
        print("CACACAC");
    }
    // Update is called once per frame
    public void Update()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey)) {
                print("WEAEAAEAEEA");
                if (noteSlider != null && keyBoardEntries.Contains(vKey.ToString()) == true)
                {
                    int idx = (keyBoardEntries.Length - 1) - keyBoardEntries.IndexOf(vKey.ToString());
                    //Grossisement du slider lors de l'appui de la touche correspondante (keyBoardEntries).
                    noteSlider[idx].transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                    //Recuperation de l'AudioSource du slider
                    AudioSource audioData = noteSlider[idx].GetComponent<AudioSource>();
                    //Lancement de l'AudioClip
                    audioData.Play(0);
                }
            }
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

    private void SortNoteSliderPosition()
    {
        bool sorted = false;
        GameObject tmp;

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