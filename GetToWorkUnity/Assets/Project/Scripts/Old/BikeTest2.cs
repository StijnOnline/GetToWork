using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BikeTest2 : MonoBehaviour {

    private Rigidbody rb;
    private float steerValue;
    public float steerSpeed;
    public float balanceForce;
    public float speed;
    public WheelCollider frontWheel;
    public WheelCollider backWheel;
    public LayerMask isGround;
    public LayerMask isWall;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0f,2f,0f);
    }

    private void Update() {
        steerValue += Input.GetAxisRaw("Horizontal") / 100f * steerSpeed;
        //rb.MoveRotation( transform.rotation * Quaternion.AngleAxis(steerValue, transform.up)); //steering
        frontWheel.steerAngle = steerValue;
        backWheel.motorTorque = speed;

        //rb.AddForce(transform.forward * speed);

        rb.AddTorque(transform.forward * balanceForce * transform.rotation.z);

        RaycastHit hit;
        if(Physics.Raycast(rb.position, -transform.up, out hit, 3f, isGround)) {
            //Vector3 projection = Vector3.ProjectOnPlane(transform.forward, hit.normal);
            //Quaternion rotation = Quaternion.LookRotation(projection, hit.normal);
            //rb.MoveRotation(Quaternion.Lerp(rb.rotation, rotation, Time.deltaTime * 5f));
            //rb.AddTorque(transform.forward * balanceForce * Vector3.Dot( transform.up,hit.normal));
        }
        

    }

    /*void OnCollisionStay(Collision collision) {
        //If the ship has collided with an object on the Wall layer...
        if(collision.gameObject.layer == isWall) {
            //...calculate how much upward impulse is generated and then push the vehicle down by that amount 
            //to keep it stuck on the track (instead up popping up over the wall)
            Vector3 upwardForceFromCollision = Vector3.Dot(collision.impulse, transform.up) * transform.up;
            rb.AddForce(-upwardForceFromCollision, ForceMode.Impulse);
        }
    }*/

}