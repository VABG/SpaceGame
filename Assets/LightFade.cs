using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFade : MonoBehaviour
{
    public float fadeTime = 1;
    private float startTime;
    private float divider = 1;
    private Light l;
    // Start is called before the first frame update
    void Start()
    {
        l = GetComponent<Light>();
        startTime = fadeTime;
    }

    // Update is called once per frame
    void Update()
    {
        fadeTime -= Time.deltaTime;
        l.intensity = fadeTime / startTime;
    }
}
