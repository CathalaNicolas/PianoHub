using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public TextMesh text = null;
    public int actualCombo = 0;

    public void Start()
    {
        text = this.GetComponentInChildren<TextMesh>();
        if (!text)
            Debug.LogError("Combo manager: text is null !");
    }

    public void setCombo(int value)
    {
        text.text = value.ToString();
    }

    public void addCombo(int value)
    {
        actualCombo = Int32.Parse(text.text);

        text.text = (actualCombo + value).ToString();
    }
}
