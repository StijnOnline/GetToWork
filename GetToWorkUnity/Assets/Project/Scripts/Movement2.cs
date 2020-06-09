﻿using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class Movement2 : MonoBehaviour {
    public float BrakeSpeed = 8.0f;
    public float NormalSpeed = 12.0f;
    public float BoostSpeed = 16.0f;
    [SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
    [SerializeField] private float m_JumpSpeed;
    [SerializeField] private float m_StickToGroundForce;
    [SerializeField] private float m_GravityMultiplier;
    [SerializeField] private bool m_UseFovKick;
    [SerializeField] private FOVKick m_FovKick = new FOVKick();
    [SerializeField] private float m_StepInterval;
    //[SerializeField] private AudioClip m_JumpSound;
    [SerializeField] private AudioClip m_LandSound;

    [SerializeField] private NewSteerInput m_SteerInput;
    private Camera m_Camera;
    //private bool m_Jump;
    private float m_YRotation;
    private Vector2 m_Input;
    private Vector3 m_MoveDir = Vector3.zero;
    private CharacterController m_CharacterController;
    private CollisionFlags m_CollisionFlags;
    private bool m_PreviouslyGrounded;
    private Vector3 m_OriginalCameraPosition;
    private bool m_Jumping;
    [SerializeField] private Transform m_body; 
    public LayerMask groundLayer;
    private AudioSource m_AudioSource;

    // Use this for initialization
    private void Start() {
        m_CharacterController = GetComponent<CharacterController>();
        m_Camera = Camera.main;
        m_OriginalCameraPosition = m_Camera.transform.localPosition;
        m_FovKick.Setup(m_Camera);
        m_Jumping = false;

        m_AudioSource = GetComponent<AudioSource>();
        if(m_AudioSource == null) {
            m_AudioSource = gameObject.AddComponent<AudioSource>();
        }
    }


    // Update is called once per frame
    private void Update() {
        RotateView();

        /*if(!m_Jump) {
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }*/

        if(!m_PreviouslyGrounded && m_CharacterController.isGrounded) {
            PlayLandingSound();
            m_MoveDir.y = 0f;
            m_Jumping = false;
        }
        if(!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded) {
            m_MoveDir.y = 0f;
        }

        m_PreviouslyGrounded = m_CharacterController.isGrounded;
    }


    private void PlayLandingSound() {
        m_AudioSource.clip = m_LandSound;
        m_AudioSource.Play();
    }

    private float GetTargetSpeed() {
        if(m_SteerInput.brake > 0.1f) {
            return BrakeSpeed;
        } else if(m_SteerInput.boost > 0.1f) {
            return BoostSpeed;
        } else {
            return NormalSpeed;
        }
    }

    private void FixedUpdate() {
        float speed = GetTargetSpeed();
        Vector3 desiredMove = transform.forward;

        // get a normal for the surface that is being touched to move along it
        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
                           m_CharacterController.height / 2f, groundLayer, QueryTriggerInteraction.Ignore);
        desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

        m_MoveDir.x = desiredMove.x * speed;
        m_MoveDir.z = desiredMove.z * speed;


        if(m_CharacterController.isGrounded) {
            if(Physics.Raycast(transform.position - transform.up * 0.2f + 0.2f * transform.forward, -transform.up, 0.2f, groundLayer)) 
                m_MoveDir.y = -m_StickToGroundForce;

            /*if(m_Jump) {
                m_MoveDir.y = m_JumpSpeed;
                PlayJumpSound();
                m_Jump = false;
                m_Jumping = true;
            }*/
        } else {
            m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime;
        }
        m_CollisionFlags = m_CharacterController.Move(m_MoveDir * Time.fixedDeltaTime);

        //using two raycasts, try to align the body to the ground
        RaycastHit hit;
        if(Physics.Raycast(transform.position - transform.up * 0.2f + 0.1f * transform.forward , -transform.up, out hit, 0.2f, groundLayer)) {
            Vector3 normal1 = hit.normal;
            if(Physics.Raycast(transform.position - transform.up * 0.2f - 0.1f * transform.forward, -transform.up, out hit, 0.2f, groundLayer)) {
                Vector3 normal2 = hit.normal;
                if(Vector3.Dot(normal1, normal2) > 0.3f) {
                    Vector3 avgNormal = (normal1 + normal2).normalized;

                    Quaternion rotation = Quaternion.LookRotation(desiredMove, avgNormal);
                    m_body.rotation = Quaternion.Lerp(m_body.rotation, rotation, Time.deltaTime * 5f);
                }
            }
        }

    }


    /*private void PlayJumpSound() {
        m_AudioSource.clip = m_JumpSound;
        m_AudioSource.Play();
    }*/

    private void RotateView() {
        Quaternion Rotation = Quaternion.AngleAxis(m_SteerInput.Steering, Vector3.up);
        transform.rotation *= Rotation;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;
        //dont move the rigidbody if the character is on top of it
        if(m_CollisionFlags == CollisionFlags.Below) {
            return;
        }

        if(body == null || body.isKinematic) {
            return;
        }
        body.AddForceAtPosition(m_CharacterController.velocity * 0.1f, hit.point, ForceMode.Impulse);
    }
}

