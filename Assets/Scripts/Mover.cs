using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
