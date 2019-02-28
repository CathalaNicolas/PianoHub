using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoCatchNote : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            Destroy(collision.gameObject);
        }
    }
}
