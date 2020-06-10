using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyOnCollision : MonoBehaviour
{
    private Rigidbody rb;
    private LayerMask requireLayer;
    private string requireTag;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag(requireTag) && ((1<<collision.gameObject.layer & requireLayer.value) != 0)) {

            rb.isKinematic = false;

        }

    }
}