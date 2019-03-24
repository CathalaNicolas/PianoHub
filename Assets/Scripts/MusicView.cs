using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;
using System;
using UnityEngine.Events;

public class MusicView : MonoBehaviour
{

    public MidiFilePlayer preFabMFP;
    public MidiStreamPlayer preFabMSP;

    public Material materialAltNote;
    public Material materialNormalNote;
   public MidiFilePlayer midiFilePlayer;
    public MidiStreamPlayer midiStreamPlayer;
    public MNote NoteDisplay;
    public GameObject[] sliders = null;

    void Start()
    {
        midiFilePlayer = Instantiate(preFabMFP);
        midiStreamPlayer = Instantiate(preFabMSP);
        DontDestroyOnLoad(midiFilePlayer);
        DontDestroyOnLoad(midiStreamPlayer);

        midiFilePlayer.MPTK_PlayOnStart = false;
        midiFilePlayer.MPTK_DirectSendToPlayer = false;
        if (!midiStreamPlayer || !midiFilePlayer)
        {
            Debug.LogError("MSP or MFP is null can't create music");
            return;
        }
        sliders = GameObject.FindGameObjectsWithTag("noteSlider");
        // If call is already set from the inspector there is no need to set another listeneer
        if (midiFilePlayer.OnEventNotesMidi.GetPersistentEventCount() == 0)
        {
            // No listener defined, set now by script. NotesToPlay will be called for each new notes read from Midi file
            Debug.Log("No OnEventNotesMidi defined, set by script");
            midiFilePlayer.OnEventNotesMidi = new MidiFilePlayer.ListNotesEvent();
            midiFilePlayer.OnEventNotesMidi.AddListener(NotesToPlay);
        }
        midiFilePlayer.MPTK_MidiName = "auclair_pno";
        playMusic();
    }
    
    public void playMusic()
    {
        if (!midiFilePlayer)
        {
            Debug.LogError("MFP is null can't start music");
            return;
        }
        midiFilePlayer.MPTK_Play();
    }

    public void stopMusic()
    {
        midiFilePlayer.MPTK_Stop();
    }

    public void pauseMusic()
    {
        midiFilePlayer.MPTK_Pause();
    }

    //Create the Note that needs to be played
    public void NotesToPlay(List<MidiNote> notes)
    {
        foreach (MidiNote note in notes)
        {
            //Check for note in piano's range (88 keys from 21 to 109)
            if (note.Midi > 20 && note.Midi < 110 && sliders != null)
            {
                MNote n = Instantiate(NoteDisplay);
                DontDestroyOnLoad(n);

                //Set the corresponding slider as the parent
                //Set rotation and position to the parent.
                GameObject slider = sliders[(note.Midi - 20)];
                n.transform.SetParent(slider.transform);

                //Trick because if your parent object is non-uniformly scaled (cf: the slider isn't), 
                //there is no reliable way to avoid that child objects get scaled or skewed.
//                n.transform.localScale = new Vector3(1.5F, 150F, 0.0125F * ((float)note.Duration / 100F));

                n.transform.rotation = slider.transform.rotation;
                n.transform.position = new Vector3(slider.transform.position.x, slider.transform.position.y,
                    slider.transform.position.z + (slider.transform.localScale.z / 2F) + (n.transform.localScale.z / 2));


                n.gameObject.SetActive(true);
                n.midiFilePlayer = midiFilePlayer;
                n.note = note;
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
                DestroyImmediate(noteview.gameObject);
        }
    }

}