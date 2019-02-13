using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private string MusicName { get; set; }
    private float Duration { get; set; }
    public List<Note> ListNote = null;
    public List<GameObject> instantiatedNote = null;
    public GameObject notePreFab;
    public float timePausedStart = 0.0F;
    public float timePausedEnd = 0.0F;
    public float timeStart = -1F;
    public bool start = false;

    private void Start()
    {
        ListNote = new List<Note>();
        GameObject.DontDestroyOnLoad(this.gameObject);
        GameObject.DontDestroyOnLoad(notePreFab);
        print("Music created");
    }

    private void OnDestroy()
    {
        this.MusicReset();
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

            foreach (Note Note in ListNote)
            {
                //Condition pour savoir si c'est le moment de faire tomber la note
                if ((Time.time - timeStart) >= Note.SpawnTimer + (timePausedEnd - timePausedStart) && Note.active == false)
                {
                    GameObject _note = Instantiate(notePreFab, Note.GetNotePos(), Quaternion.identity);
                    instantiatedNote.Add(_note);
                    GameObject.DontDestroyOnLoad(_note);
                    Note.active = true;
                }
                //On bouge la note
                foreach (GameObject NoteObject in instantiatedNote)
                {
                    //NoteObject.transform.Translate(new Vector3(0, 0, -1 * (Time.deltaTime * 0.01F)), Camera.main.transform);

                    NoteObject.transform.position= new Vector3(NoteObject.transform.position.x, NoteObject.transform.position.y, NoteObject.transform.position.z -1 * (Time.deltaTime * 0.01F));
                }
            }
        }
    }

    public void AddNote(int index, float SpawnTimer, float NoteDuration)
    {
        Note newNote = new Note(index, SpawnTimer, NoteDuration);

        print("Adding Note !");
        ListNote.Add(newNote);
    }

    public void MusicReset()
    {
        foreach (GameObject note in instantiatedNote)
            Destroy(note);
        foreach (Note note in ListNote)
            note.active = false;
        start = false;
        instantiatedNote = new List<GameObject>();
        timePausedStart = 0.0F;
        timePausedEnd = 0.0F;
        timeStart = -1F;
        print("Music Reset !");
    }
}
