using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody body;
    float accelerationForce = 500;
    float rotationForce = 41f;
    public GameObject visuals;
    public GameObject broken;

    public GameObject[] disabledOnDeath;
    public bool active = true;
    public bool dead = false;
    public ParticleSystem exhaustPFX;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.centerOfMass += new Vector3(0, -.10f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (active) DoInput();
    }

    private void DoInput()
    {
        Vector3 acceleration = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            body.AddRelativeForce(Vector3.up * accelerationForce * Time.deltaTime);
            if (!exhaustPFX.isEmitting) exhaustPFX.Play();
        }
        else if (exhaustPFX.isEmitting) exhaustPFX.Stop();

        float rotation = 0;
        if (Input.GetKey(KeyCode.A))
        {
            rotation -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotation += 1;
        }
        body.AddRelativeTorque(Vector3.back * rotation * rotationForce*Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        //IF BASE COLLIDER OR ENEMY
        if (collision.contacts[0].thisCollider.name != "SafeCollider" || collision.collider.tag == "Enemy")
        {
            Die();
        }
        //ELSE CHECK SPEED (bottom collider)
        else
        {
            if (collision.impulse.magnitude > 2) Die();
        }
    }

    public void Die()
    {
        visuals.SetActive(false);
        GetComponent<Collider>().enabled = false;
        GetComponent<PlanetGravity>().enabled = false;
        foreach (GameObject o in disabledOnDeath)
        {
            o.SetActive(false);
        }
        broken.SetActive(true);
        Rigidbody[] bodies = broken.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody b in bodies)
        {
            b.velocity = body.velocity;
            b.angularVelocity = body.angularVelocity;
            b.velocity += Vector3.Normalize(b.transform.position - transform.position) * 3;
        }
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        active = false;
        dead = true;
        GameMgr.AddDeath();
    }

    public void Win()
    {
        active = false;
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
        GetComponent<PlanetGravity>().enabled = false;
    }
}
