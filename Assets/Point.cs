using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Level lvl;

    private void OnTriggerEnter(Collider other)
    {
        lvl.AddScore();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Play PFX
    }
}
