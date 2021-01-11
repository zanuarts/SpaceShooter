using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
