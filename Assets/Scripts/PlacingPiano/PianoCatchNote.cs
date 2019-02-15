using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoCatchNote : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            print("Collision note!");
            Destroy(collision.gameObject);
        }
    }
}
