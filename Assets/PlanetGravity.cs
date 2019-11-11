using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 g = Gravity.GetGravity(transform.position);
        body.AddForce(g * 110 * Time.fixedDeltaTime);
    }
}
