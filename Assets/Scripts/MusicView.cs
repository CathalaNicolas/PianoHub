using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;
using System;
using UnityEngine.Events;

public class MusicView : MonoBehaviour
{

    public MidiFilePlayer midiFilePlayer;
    public MidiStreamPlayer midiStreamPlayer;
    public MNote NoteDisplay;
    public GameObject[] sliders = null;

    public void EndLoadingSF()
    {
        Debug.Log("End loading SF, MPTK is ready to play");
        Debug.Log("   Time To Load SoundFont: " + Math.Round(MidiPlayerGlobal.MPTK_TimeToLoadSoundFont.TotalSeconds, 3).ToString() + " second");
        Debug.Log("   Time To Load Waves: " + Math.Round(MidiPlayerGlobal.MPTK_TimeToLoadWave.TotalSeconds, 3).ToString() + " second");
        Debug.Log("   Presets Loaded: " + MidiPlayerGlobal.MPTK_CountPresetLoaded);
        Debug.Log("   Waves Loaded: " + MidiPlayerGlobal.MPTK_CountWaveLoaded);
    }

    void Start()
    { 
        sliders = GameObject.FindGameObjectsWithTag("noteSlider");
        // If call is already set from the inspector there is no need to set another listeneer
        if (midiFilePlayer.OnEventNotesMidi.GetPersistentEventCount() == 0)
        {
            // No listener defined, set now by script. NotesToPlay will be called for each new notes read from Midi file
            Debug.Log("No OnEventNotesMidi defined, set by script");
            midiFilePlayer.OnEventNotesMidi = new MidiFilePlayer.ListNotesEvent();
            midiFilePlayer.OnEventNotesMidi.AddListener(NotesToPlay);
        }
    }

    public void NotesToPlay(List<MidiNote> notes)
    {
        //Debug.Log(notes.Count);
        foreach (MidiNote note in notes)
        {
            if (note.Midi > 20 && note.Midi < 109 && sliders != null)// && note.Channel==1)
            {
                Vector3 position = new Vector3(sliders[(note.Midi - 20)].transform.position.x,
                    sliders[(note.Midi - 20)].transform.position.y,
                    sliders[(note.Midi - 20)].transform.position.z + (sliders[(note.Midi - 20)].transform.localScale.z / 2) + (0.04f + (note.Length / 10000F)));
                MNote n = Instantiate<MNote>(NoteDisplay, position, Quaternion.identity);

                n.gameObject.transform.localScale += new Vector3(0, 0, (note.Length / 10000f));
                //((float)note.Duration / 10000f));
                                                                                               // print("DEBUG: Duration " + (note.Length / 10000f));
                n.gameObject.SetActive(true);
                n.midiFilePlayer = midiFilePlayer;
                n.note = note;
                n.note.Duration = n.note.Duration / 2;
                n.note.Midi = note.Midi;
                n.gameObject.GetComponent<Renderer>().material = n.NewNote;
                /*  MPTKNote mptkNote = new MPTKNote() { Delay = 0, Drum = false, Duration = 0.2f, Note = 60, Patch = 10, Velocity = 100 };
                  mptkNote.Play(midiStreamPlayer);*/
            }
        }
    }
    public void Clear()
    {
        MNote[] components = GameObject.FindObjectsOfType<MNote>();
        foreach (MNote noteview in components)
        {
            if (noteview.enabled)
                //Debug.Log("destroy " + ut.name);
                DestroyImmediate(noteview.gameObject);
        }
    }

}