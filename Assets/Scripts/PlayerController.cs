using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
    public float yMin, yMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shoot;
    public Transform shootSpawn;
    
    public float fireRate;
    public float nextFire;

    Rigidbody rigidbody;
    AudioSource audio;

    void Start(){
        rigidbody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update(){
        if (Input.GetButton("Fire1") && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Instantiate (shoot, shootSpawn.position, shootSpawn.rotation);
            audio.Play();
        }
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (0.0f,  moveVertical, moveHorizontal);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3 (
            0.0f,
            Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax),
            Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.y * -tilt);
    }
}
