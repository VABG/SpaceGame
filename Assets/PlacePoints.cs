using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePoints : MonoBehaviour
{

    public GameObject SpawnPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] t = GetComponentsInChildren<Transform>();
        for (int i = 0; i < t.Length; i++)
        {
            if (this.transform == t[i]) continue;
            Instantiate(SpawnPrefab, t[i]); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
