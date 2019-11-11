using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 1, -4);
    private float lookAtPos;
    public Transform startPlanet;
    public Transform endPlanet;
    float yOffsetMult = 1;
    float yDistance;

    // Start is called before the first frame update
    void Start()
    {
        yDistance = endPlanet.position.y - startPlanet.position.y - startPlanet.localScale.y - endPlanet.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Change y-offset for position when nearing goal
        if (endPlanet.position.y - target.position.y < 12) yOffsetMult = -.75f;
        else yOffsetMult = 1;


        Vector3 pos = Vector3.Lerp(transform.position, target.position + new Vector3(offset.x, offset.y * yOffsetMult, offset.z), 1 * Time.deltaTime);
        pos.x = 0;
        transform.position = pos;


        float offsetRes = target.position.y + offset.y;
        lookAtPos = Mathf.Lerp(lookAtPos, offsetRes, 3f * Time.deltaTime);
        transform.LookAt(new Vector3(0, lookAtPos, 0));
    }
}
