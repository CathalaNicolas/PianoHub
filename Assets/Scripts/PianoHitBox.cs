using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoHitBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Got collision is note?");
        //Verifie si le gameObject rentré en collision avec la PianoHitBox est une note
        if (collision.gameObject.tag == "Note")
        {
            print("Yes it is note");
            //Recuperation du Renderer pour pouvoir modifier la couleur du Material associé
            Renderer rend = collision.gameObject.GetComponent<Renderer>();
            rend.material.SetColor("_Color", Color.green);
        }
    }
}
