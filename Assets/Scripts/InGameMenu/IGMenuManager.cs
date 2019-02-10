using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMenuManager : MonoBehaviour
{
    private GameObject[] noteSlider = null;
    private GameObject piano = null;
    // Start is called before the first frame update
    void Start()
    {
        print("Created IGMenu manager");
        noteSlider = GameObject.FindGameObjectsWithTag("noteSlider");
        piano = GameObject.FindGameObjectWithTag("Piano");

        if (noteSlider == null || piano == null)
        {
            print("noteSlider ou piano null !");
            return;
        }
        for (int i = 0; i < noteSlider.Length; i++) {
            noteSlider[i].SetActive(true);
        }
        piano.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
