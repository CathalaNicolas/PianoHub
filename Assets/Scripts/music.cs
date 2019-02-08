using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private string MusicName { get; set; }
    private float Duration { get; set; }
    private List<Note> ListNote = null;
    public bool start = false;

    private void Start()
    {
        ListNote = new List<Note>();
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
            List<Note> toRemove = new List<Note>();

            foreach (Note Note in ListNote)
            {

                //Condition pour savoir si c'est le moment de faire tomber la note
                if (Time.time >= Note.SpawnTimer)
                {
                    //On bouge la note
                    Note.MoveNote(-0.5f);

                    print("Note : " + Note.Type + "Pos: " + Note.GetNotePos());
                    //La note passe sous le clavier, on l'ajoute à celles qui faut détruire
                    if (Note.PosY <= 0 - Note.NoteDuration)
                    {
                        print("DESTRUCTION NOTE");
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
    }

    public void SetGameObjectMusic(Music music)
    {
        print("SetGameobjectMusic !!!");
        this.MusicName = music.MusicName;
        this.Duration = music.Duration;
        this.ListNote = music.ListNote;
    }
}
