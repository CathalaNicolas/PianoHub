using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private string MusicName { get; set; }
    private float Duration { get; set; }
    private List<Note> ListNote { get; set; }

    void Start()
    {
        //Example d'ajout de music, sera geré par MusicManager par la suite. Mais la création restera la même. (addNote(Type, SpawnTime, Durée)).
        this.MusicName = MusicName;
        this.Duration = Duration;
        ListNote = new List<Note>();
 
        AddNote(NoteType.SOL, 0f, 1f);
        AddNote(NoteType.SOL, 1f, 1f);
        AddNote(NoteType.SOL, 2f, 1f);
        AddNote(NoteType.LA, 3f, 1f);
        AddNote(NoteType.SI, 4f, 1f);
        AddNote(NoteType.SOL, 4f, 1f);
        AddNote(NoteType.LA, 5f, 1f);

    }
    
    void Update()
    {
        List<Note> toRemove = new List<Note>();

        foreach (Note Note in ListNote)
        {
            //Condition pour savoir si c'est le moment de faire tomber la note
            if (Time.time >= Note.SpawnTimer)
            {
                //On bouge la note
                Note.MoveNote(-0.5f);
                //La note passe sous le clavier, on l'ajoute à celles qui faut détruire
                if (Note.PosY <= 0 - Note.NoteDuration)
                {
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

    public void AddNote(NoteType type, float SpawnTimer, float NoteDuration)
    {
        Note newNote = new Note(type, SpawnTimer, NoteDuration);
        
        ListNote.Add(newNote);
    }
}
