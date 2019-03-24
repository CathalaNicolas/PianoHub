using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class MusicLoader : MonoBehaviour
{
    public Music music = null;

    public void Start()
    {
   
        GameObject musicObject = GameObject.FindWithTag("Music");
        if (musicObject != null)
        {
            music = musicObject.GetComponent<Music>();
        }

    }
    public void OnDestroy()
    {
        print("Destroying MusicLoader");
    }
    public Music LoadMusicFromPath(string Path)
    {
        if (music != null)
        {
            if (File.Exists(Path))
            {
                using (StreamReader sr = File.OpenText(Path))
                {
                    LoadMusic(sr);
                }
            }
            return (music);
        }
        return (null);
    }

    public void LoadMusic(StreamReader sr)
    {
        string line;
        string[] parts;
        float SpawnTime = -1f;
        float duration = -1f;
        NoteType type = NoteType.UNKNOWN;


        //Parsing des lignes du fichier, doit avoir la forme NoteType;SpawnTime;Duration
        while ((line = sr.ReadLine()) != null)
        {
            parts = line.Split(';');

            if (parts.Length - 1 < 2)
                return;
            type = StringToNoteType(parts[0]);
            if (type == NoteType.UNKNOWN)
                return;
            SpawnTime = float.Parse(parts[1], CultureInfo.InvariantCulture.NumberFormat);
            duration = float.Parse(parts[2], CultureInfo.InvariantCulture.NumberFormat);
          //  music.AddNote(type, SpawnTime, duration);
        }
        return;
    }

    private NoteType StringToNoteType(string type)
    {
        switch (type)
        {
            case "DO":
                return (NoteType.DO);
            case "RE":
                return (NoteType.RE);
            case "MI":
                return (NoteType.MI);
            case "FA":
                return (NoteType.FA);
            case "SOL":
                return (NoteType.SOL);
            case "LA":
                return (NoteType.LA);
            case "SI":
                return (NoteType.SI);
        }
        return (NoteType.UNKNOWN);
    }
}
