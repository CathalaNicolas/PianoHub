using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoHitBox : MonoBehaviour
{

    public GameManager gameManager = null;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager == null)
        {
            print("GameManager can't be found.");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Verifie si le gameObject rentré en collision avec la PianoHitBox est une note
        if (collision.gameObject.tag == "Note")
        {
            MNote note = collision.gameObject.GetComponent<MNote>();
            if (note.played != true)
            {
                Renderer rend = note.GetComponent<Renderer>();

                note.midiFilePlayer.MPTK_PlayNote(note.note);
                note.played = true;

                if (gameManager.keyManager.getActiveKey().Contains(note.note.Midi - 20))
                {
                    rend.material.SetColor("_Color", Color.green);
                    note.startHit = true;
                    score = 300;
                }
                else
                {
                    rend.material.SetColor("_Color", Color.yellow);
                    gameManager.combo.setCombo(0);
                    score = 150;
                }
            }
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            MNote note = collision.gameObject.GetComponent<MNote>();
            Renderer rend = note.GetComponent<Renderer>();

            if (gameManager.keyManager.getActiveKey().Contains(note.note.Midi - 20))
            {
                if (note.startHit == true)
                    gameManager.combo.addCombo(1);
                note.stayHit = true;
            }
            else
            {
                score = 0;
                rend.material.SetColor("_Color", Color.red);
                gameManager.combo.setCombo(0);
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            MNote note = collision.gameObject.GetComponent<MNote>();
            Renderer rend = note.GetComponent<Renderer>();

            Destroy(collision.gameObject);
        }
    }
}
