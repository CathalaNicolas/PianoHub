using MidiPlayerTK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MNote : MonoBehaviour
{
    public MidiNote note;
    public MidiFilePlayer midiFilePlayer;
    public bool played = false;
    public bool startHit = false;
    public bool stayHit = false;
    public Material NewNote;
    public Material WaitingNote;
    public Material ReadyNote;
    public int[] altNote = {1, 4, 6, 9, 11, 13, 16,  18, 21, 23, 25, 28, 30, 33,
                            35, 37, 40, 42, 45, 47, 49, 52, 54, 57, 59, 61, 64, 66,
                            69, 71, 73, 76, 78, 81, 83, 85};


    public bool isNoteAlt(int midiValue)
    {
        foreach (int value in altNote)
        {
            if (midiValue == value)
                return true;
        }
        return false;
    }

    private void Start()
    {
        Renderer renderer = this.GetComponent<Renderer>();


        if (!renderer.material)
            Debug.LogError("material is null");
        if (isNoteAlt(note.Midi - 20))
        {
            //renderer.material = Resources.Load<Material>("/preFabs/materialAltNote");
            renderer.material.SetColor("_Color", Color.cyan);
            // renderer.material = materialAltNote;
        }
        else
        {

            //renderer.material = Resources.Load<Material>("/preFabs/materialNormalNote");
            renderer.material.SetColor("_Color", Color.blue);
        }

    }
    void FixedUpdate()
    {
        float translation = Time.fixedDeltaTime * 1f;
        this.transform.Translate(Vector3.forward * -translation, this.transform.parent);
    }

}
