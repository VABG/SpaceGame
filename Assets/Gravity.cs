using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    static Transform[] planets;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetPlanets(Transform[] planets)
    {
        Gravity.planets = planets;
    }

    public static Vector3 GetGravity(Vector3 position)
    {
        Vector3 gravity = Vector3.zero;
        foreach (Transform t in planets)
        {
            Vector3 direction = t.position - position;
            float d = Vector3.SqrMagnitude(direction);
            direction = direction.normalized;

            gravity += (direction * (1 / d)) * t.localScale.x*t.localScale.x;
        }
        return gravity;
    }
}
