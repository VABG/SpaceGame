using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private Level lvl;
    private Light l;
    private bool fadeLight = false;
    private float fadeTime = 1f;
    private void Start()
    {
        l = GetComponent<Light>();
        lvl = FindObjectOfType<Level>();
    }

    private void Update()
    {
        if (l != null && fadeLight)
        {
            fadeTime -= Time.deltaTime;
            if (fadeTime <= 0)
            {
                l.enabled = false;
                fadeLight = false;
                this.gameObject.SetActive(false);
                return;
            }
            l.intensity = fadeTime;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        lvl.AddScore();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<ParticleSystem>().Play();
        //Play PFX
        fadeLight = true;
    }
}
