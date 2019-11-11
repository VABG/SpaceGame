using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBorder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        Player p = other.GetComponent<Player>();
        if (p == null) return;

        p.Die();
    }
}
