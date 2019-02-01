using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesManager : MonoBehaviour
{

    public GameObject Note;
    public float classic_length = 0.0192307692307692f;
    public float to_note = 0.0096153846153846f;
    public int cpt = 0;
    public float RateOfSpawn = 2;

    public float nextSpawn = 0;

    public int TotalNotes = 12;

    private void Start()
    {
        Note = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Note.transform.position = new Vector3(-10f, -10f, -10f);
        Note.AddComponent<Fall>();
    }

    float GetNotepos(int index)
    {
        return (-index * classic_length);
    }

    Vector3 Getpos(int cpt)
    {

        if (cpt == 0 || cpt == 1 || cpt == 2 || cpt == 8 || cpt == 12)
            return (new Vector3(GetNotepos(-2), 50f, -0.5f));
        else if (cpt == 3 || cpt == 6 || cpt == 10 || cpt == 11)
            return (new Vector3(GetNotepos(-1), 50f, -0.5f));
        else if (cpt == 4 || cpt == 9)
            return (new Vector3(GetNotepos(0), 50f, -0.5f));
        else
            return (new Vector3(-1f, -1f, -1f));
    }

    float Getsize(int cpt)
    {
        if (cpt == 4 || cpt == 6)
            return (0.5f);
        else
            return (0.25f);
    }

    void Update()
    {

        if (Time.time >= nextSpawn && cpt <= TotalNotes)
        {
            nextSpawn = Time.time + RateOfSpawn;

            Vector3 pos = transform.TransformPoint(Getpos(cpt));
            Note.transform.localScale = new Vector3(0.2f, Getsize(cpt), 0.2f);
            print(pos);
            Instantiate(Note, pos, transform.rotation);
            cpt++;
            Debug.Log("Time = " + Time.time);
        }
    }
}