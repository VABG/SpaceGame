using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        EnemyPlacer[] e = GetComponentsInChildren<EnemyPlacer>();
        Transform[] t = GetComponentsInChildren<Transform>();
        for (int i = 0; i < e.Length; i++)
        {
            GameObject o = Instantiate(enemyPrefab, t[i+1]);
            EnemySideWays p = o.GetComponent<EnemySideWays>();
            p.movingRight = e[i].goRight;
            p.speed = e[i].velocityX;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
