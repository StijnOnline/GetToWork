using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeTest : MonoBehaviour {
    public float steerValue = 0;
    public float steerSpeed = 1;
    public float speed = 1;
    public float wheelRadius = 1;
    //private Rigidbody rb;
    public Transform wheel1;
    public Transform wheel2;
    public LayerMask bikeMask;

    void Start() {
        //rb = GetComponent<Rigidbody>();
    }

    void Update() {
        UpdateBike();
    }

    void UpdateBike() {
        steerValue += Input.GetAxisRaw("Horizontal") / 100f * steerSpeed;
        transform.Translate(speed * transform.forward);
        transform.rotation *= Quaternion.AngleAxis(steerValue, transform.up); //steering

        RaycastHit hit;
        if(!Physics.Raycast(wheel1.position, -wheel1.transform.up, out hit, 3f, bikeMask))
            return;

        if(!Physics.Raycast(wheel1.position, -hit.normal, out hit, 3f, bikeMask))
            return;


        Vector3 wheel1GroundPos = hit.point;
        if(!Physics.Raycast(wheel2.position, -wheel2.transform.up, out hit, 3f, bikeMask))
            return;
        if(!Physics.Raycast(wheel2.position, -hit.normal, out hit, 3f, bikeMask))
            return;



        


        Vector3 wheel2targetPos = hit.point + hit.normal * wheelRadius;
        transform.position -= wheel2.position - wheel2targetPos;

        
    }
}
