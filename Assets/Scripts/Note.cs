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
    public GameObject NoteObject;


    public Note(NoteType type, float SpawnTimer, float NoteDuration)
    {
        //Creation du GameObject Note, avec son type primitif (cube), un matériau (pour appliquer une couleur), et une couleur
        NoteColor = new Color(125f, 125f, 125f);
        NoteObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        MaterialPropertyBlock props = new MaterialPropertyBlock();
        props.SetColor("_Color", Color.red);
        NoteObject.GetComponent<Renderer>().SetPropertyBlock(props);

        //On défini les positions de bases, le moment auquel la note apparaît, son speed et son type.
        this.PosY = 15f;
        this.PosZ = 1.5f;
        SetNotePosByType(type);
        this.SpawnTimer = SpawnTimer;
        this.NoteDuration = NoteDuration;
        this.NoteSpeed = 1 * this.NoteDuration;
        this.Type = type;

        //On défini le scale de l'object (sa taille), puis un vieux tricks pour pas voir la note dès le départ, 
        NoteObject.transform.localScale= new Vector3(0.2f, NoteDuration, 0.2f);
        NoteObject.transform.position = new Vector3(-10f, -10f, -10f);
    }

    public void SetNoteColor(float r, float g, float b)
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
    public void MoveNote(float Distance)
    {
        NoteObject.transform.position = new Vector3(PosX, PosY - 0.2f, PosZ);
        PosY -= 0.2f;
    }
    public Vector3 GetNotePos()
    {
        return (new Vector3(PosX, PosY, PosZ));
    }
}
