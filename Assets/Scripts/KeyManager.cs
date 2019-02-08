using System.Collections;
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
    }

    private void OnDestroy()
    {
        print("CACACAC");
    }
    // Update is called once per frame
    public void Update()
    {

        print("WOOO");
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
}
