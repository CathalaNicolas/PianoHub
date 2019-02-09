using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private string MusicName { get; set; }
    private float Duration { get; set; }
    public List<Note> ListNote = null;
    public List<Note> permanentListNote = null;
    public float timePausedStart = 0.0F;
    public float timePausedEnd = 0.0F;
    public float timeStart = -1F;
    public bool start = false;

    private void Start()
    {
        ListNote = new List<Note>();
        permanentListNote = new List<Note>();
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    private void OnDestroy()
    {
        print("Music destroyed");
    }

    public void PrintInfo()
    {
        foreach (Note note in ListNote)
            print(note.InfoToString());
    }

    void Update()
    {
        if (start == true)
        {
            if (timeStart == -1)
                timeStart = Time.time;
            List<Note> toRemove = new List<Note>();

            foreach (Note Note in ListNote)
            {

                //Condition pour savoir si c'est le moment de faire tomber la note
                if ((Time.time - timeStart) >= Note.SpawnTimer + (timePausedEnd - timePausedStart))
                {
                    //On bouge la note
                    Note.MoveNote(-0.5f);

                    //print("Note : " + Note.Type + "Pos: " + Note.GetNotePos());
                    //La note passe sous le clavier, on l'ajoute à celles qui faut détruire
                    if (Note.PosY <= 0 - Note.NoteDuration)
                    {
                        //print("DESTRUCTION NOTE");
                        Destroy(Note.NoteObject);
                        toRemove.Add(Note);
                    }
                }
            }
            foreach (Note Note in toRemove)
            {
                ListNote.Remove(Note);
            }
        }
    }

    public void AddNote(NoteType type, float SpawnTimer, float NoteDuration)
    {
        Note newNote = new Note(type, SpawnTimer, NoteDuration);

        print("Adding Note !");
        ListNote.Add(newNote);
        permanentListNote.Add(new Note(type, SpawnTimer, NoteDuration));
    }

    public void MusicReset()
    {
        foreach (Note note in ListNote)
        {
            Destroy(note.NoteObject);
        }
        ListNote.Clear();
        foreach (Note note in permanentListNote)
        {
            ListNote.Add(new Note(note.Type, note.SpawnTimer, note.NoteDuration));
            print(note.InfoToString());
        }
        start = false;
        timePausedStart = 0.0F;
        timePausedEnd = 0.0F;
        timeStart = -1F;
        print("Music Reset !");
    }
}
