using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody physics;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vector3;
    public float speed = 10;
    public float minX, maxX, minZ, maxZ;
    public float slope;
    float fireTime = 0;
    public float transitTime;
    public GameObject bullet;
    public Transform leadOutlet;
    AudioSource audio;


    void Start()
    {        
        physics = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    
    }

     void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > fireTime)
        {
            fireTime = Time.time + transitTime;
            Instantiate(bullet, leadOutlet.position, Quaternion.identity);
            audio.Play();
        }
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        vector3 = new Vector3(horizontal,0,vertical);
        physics.velocity = vector3 * speed;

        physics.position = new Vector3
            (
            Mathf.Clamp(physics.position.x, minX, maxX),
            0.0f,
            Mathf.Clamp(physics.position.z,minZ,maxZ)
            );

        physics.rotation = Quaternion.Euler(0,0,physics.velocity.x * -slope);
    }
}
