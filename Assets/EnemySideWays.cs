using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideWays : MonoBehaviour
{
    public float distanceFromCenter;
    public bool movingRight;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        if (movingRight)
        {
            GetComponent<Rigidbody>().velocity = (Vector3.right * speed);
            transform.rotation = Quaternion.Euler((Vector3.up * 180));
        }
        else
        {
            GetComponent<Rigidbody>().velocity = (Vector3.left * speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {            
            if (transform.position.x > distanceFromCenter)
                transform.position = new Vector3(-distanceFromCenter, transform.position.y, transform.position.z);
        }
        else
        {
            if (transform.position.x < -distanceFromCenter)
                transform.position = new Vector3(distanceFromCenter, transform.position.y, transform.position.z);
        }        
    }
}
