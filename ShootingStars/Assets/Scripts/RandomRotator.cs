using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    private Rigidbody RigBod;

    public float tumble;

    private void Awake()
    {
        RigBod = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        RigBod.angularVelocity = Random.insideUnitSphere * tumble;
    }

}
