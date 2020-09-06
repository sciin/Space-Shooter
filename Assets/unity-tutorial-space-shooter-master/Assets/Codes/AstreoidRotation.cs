using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidRotation : MonoBehaviour
{
    Rigidbody physics;
    public float turnSpeed;
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.angularVelocity = Random.insideUnitSphere * turnSpeed;
    }

}
