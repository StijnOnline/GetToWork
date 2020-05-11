using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelHolder : MonoBehaviour
{
    public Transform wheel;
    public LayerMask layerMask;
    public float maxDist = 0.5f;
    public float radius = 0.5f;
    public float lerpVal = 0.2f;

    
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward, out hit, maxDist, layerMask)) {
            wheel.position = Vector3.Lerp(wheel.position, hit.point + hit.normal * radius, lerpVal);
        } else {
            wheel.position = Vector3.Lerp(wheel.position, transform.position + transform.forward * maxDist,lerpVal);
        }
    }
}
