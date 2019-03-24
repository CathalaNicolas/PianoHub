using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyManager : MonoBehaviour
{
    private List<int> keyActive = null;

    public void Start()
    {
        keyActive = new List<int>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void addKey(int key)
    {
        if (keyActive.Contains(key))
            keyActive.Remove(key);
        else
            keyActive.Add(key);
    }

    public List<int> getActiveKey()
    {
        return keyActive;
    }

    public void parseMessage(string message)
    {
        string[] keys = message.Split('\n');

        if (keys.Length > 0)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                string[] parts = keys[i].Split(';');

                int key = Int32.Parse(parts[0]);

                addKey(key);
            }
        }
        else
        {
            string[] parts = message.Split(';');

            int key = Int32.Parse(parts[0]);

            addKey(key);
        }
    }
}
