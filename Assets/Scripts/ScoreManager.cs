using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMesh text = null;
    public int actualScore = 0;
    public ComboManager comboManager = null;

    public void Start()
    {
        text = this.GetComponentInChildren<TextMesh>();
        if (!text)
            Debug.LogError("Score manager: text is null !");
        comboManager = GameObject.FindWithTag("ComboManager").GetComponent<ComboManager>();
        if (!comboManager)
            Debug.LogError("Score manager: comboManager is null !");
    }

    public void setScore(int value)
    {
        text.text = value.ToString();
    }

    public void addScore(int value)
    {
        actualScore = Int32.Parse(text.text);

        text.text = ((actualScore + value) * comboManager.actualCombo).ToString();
    }
}
