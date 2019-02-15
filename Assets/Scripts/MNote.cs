using MidiPlayerTK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MNote : MonoBehaviour
{
    public static float Speed = 1f;

    public MidiNote note;
    public MidiFilePlayer midiFilePlayer;
    public bool played = false;
    public Material NewNote;
    public Material WaitingNote;
    public Material ReadyNote;
    
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //float translation = Time.deltaTime * 10;
        //transform.Translate(-translation, 0, 0);
        if (!played && transform.position.x < -45f)
        {
            played = true;
            /*int delta = Mathf.CeilToInt(zOriginal - transform.position.z + 0.5f);
            note.Midi += delta;*/
            //note.Midi = Midi;
            print("Debug: " + note.Midi);
        }
    }

    void FixedUpdate()
    {
        float translation = Time.fixedDeltaTime * Speed;
        transform.Translate(0, 0, -translation);
    }

}
