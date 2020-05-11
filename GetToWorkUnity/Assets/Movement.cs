using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public bool isGrounded;
    private Rigidbody rb;
    public float jumpForce;






    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
    }




    // Update is called once per frame
    void Update()
    {
        


        if (isGrounded == true && Input.GetMouseButtonDown(1))
        {
           
                rb.AddForce(Vector3.up * jumpForce);
            

           
            
            Debug.Log("jump");
        }

         
        
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
           
        

        
    }

    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * (rb.mass * rb.mass));
    }
   



}
