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

public class Note : MonoBehaviour
{
    private float PosX { get; set; }
    private float PosY { get; set; }
    private float PosZ { get; set; }
    private float NoteSpeed { get; set; }
    private float NoteLength { get; set; }
    private float SpawnTimer { get; set; }
    private float Timer { get; set; }
    private NoteType Type { get; set; }
    private Color NoteColor;
    private GameObject NoteObject;
    private readonly Renderer render;

    public Note(float PosX, float PosY, float PosZ, NoteType type)
    {
        NoteColor = new Color(125f, 125f, 125f);

        NoteObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        render = NoteObject.GetComponent<Renderer>();
        render.material = new Material(Shader.Find("Standard"))
        {
            color = NoteColor
        };
        NoteObject.transform.position.Set(PosX, PosY, PosZ);
        NoteObject.AddComponent<Fall>();

        this.PosX = PosX;
        this.PosY = PosY;
        this.PosZ = PosZ;
        this.SpawnTimer = (Time.deltaTime % 60);
        this.Timer = 0f;
        this.NoteLength = 0.5f;
        this.NoteSpeed = 1 * this.NoteLength;
    }

    public void SetNoteColor(float r, float g, float b)
    {
        render.material.color = new Color(r, g, b);
        NoteColor.r = r;
        NoteColor.g = g;
        NoteColor.b = b;
    }

    private void Update()
    {
        this.Timer += Time.deltaTime;
        if (this.Timer >= SpawnTimer)
        {
            NoteObject.transform.Translate(0, -Time.deltaTime, 0, Space.World);
        }
    }
}
