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
    private Color NoteColor;
    public bool active = false;

    public Note(NoteType type, float SpawnTimer, float NoteDuration)
    {

        //On défini les positions de bases, le moment auquel la note apparaît, son speed et son type.
        this.PosY = 15f;
        this.PosZ = 1.5f;
        SetNotePosByType(type);
        this.SpawnTimer = SpawnTimer;
        this.NoteDuration = NoteDuration;
        this.NoteSpeed = 1 * this.NoteDuration;
        this.Type = type;
    }

    public void SetNoteColor(GameObject NoteObject, float r, float g, float b)
    {
        NoteObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(r, g, b));
        NoteColor.r = r;
        NoteColor.g = g;
        NoteColor.b = b;
    }

    //Placement des Notes en fonction de leurs types, pour coincider avec les sliders.
    private void SetNotePosByType(NoteType type)
    {
        switch (type)
        {
            case NoteType.DO:
                PosX = -3f;
                break;
            case NoteType.RE:
                PosX = -2.5f;
                break;
            case NoteType.MI:
                PosX = -2f;
                break;
            case NoteType.FA:
                PosX = -1.5f;
                break;
            case NoteType.SOL:
                PosX = -1f;
                break;
            case NoteType.LA:
                PosX = -0.5f;
                break;
            case NoteType.SI:
                PosX = 0f;
                break;
        }
    }
    public Transform setTransform(GameObject note)
    {
        note.transform.position = new Vector3(PosX, PosY, PosZ);
        return (note.transform);
    }
    public void MoveNote(GameObject NoteObject, float Distance)
    {
        NoteObject.transform.position = new Vector3(PosX, PosY - Distance, PosZ);
        PosY -= Distance;
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
