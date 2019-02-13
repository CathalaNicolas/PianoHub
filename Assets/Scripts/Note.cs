using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NoteType
{
    DO,
    RE,
    MI,
    FA,
    SOL,
    LA,
    SI,
    UNKNOWN
}

public class Note
{
    public float PosX { get; set; }
    public float PosY { get; set; }
    public float PosZ { get; set; }
    private float NoteSpeed { get; set; }
    public float NoteDuration { get; set; }
    public float SpawnTimer { get; set; }
    public NoteType Type { get; set; }
    public int index;
    private Color NoteColor;
    public bool active = false;

    public Note(int index, float SpawnTimer, float NoteDuration)
    {
        Debug.Log("ici");
        GameObject[] sliders = GameObject.FindGameObjectsWithTag("noteSlider");

        if (sliders.Length != 52 || index > sliders.Length)
        {
            Debug.Log("Can't find sliders to set note position, note not created.");
            return;
        }
        //On défini les positions de bases, le moment auquel la note apparaît, son speed et son type.
        SetNotePosByType(index, sliders[index]);
        this.SpawnTimer = SpawnTimer;
        this.NoteDuration = NoteDuration;
        this.NoteSpeed = 1 * this.NoteDuration;
        this.index = index;
    }

    public void SetNoteColor(GameObject NoteObject, float r, float g, float b)
    {
        NoteObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(r, g, b));
        NoteColor.r = r;
        NoteColor.g = g;
        NoteColor.b = b;
    }

    //Placement des Notes en fonction de leurs types, pour coincider avec les sliders.
    private void SetNotePosByType(int index, GameObject slider)
    {
        PosX = slider.transform.position.x;
        PosY = slider.transform.position.y;
        PosZ = slider.transform.position.z + (slider.transform.localScale.z /2);
        Debug.Log(InfoToString());
    }

    public Vector3 GetNotePos()
    {
        return (new Vector3(PosX, PosY, PosZ));
    }
    public string InfoToString()
    {
        string result = "Note : PosX(" + PosX + "), posY(" + PosY+ "), posZ(" + PosZ + "), type = " + Type + ", NoteDuration(" + NoteDuration + ")";
     return (result);

    }
}
