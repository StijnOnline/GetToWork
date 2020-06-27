using System;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class Movement : MonoBehaviour {
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
    [SerializeField] private NewSteerInput m_SteerInput;
    [SerializeField] private Transform m_body; 
    [SerializeField] private List<AudioClip> m_LandSounds;
    [SerializeField] private int m_LandSound_Counter;
    [SerializeField] private float m_LandSoundVolume;
    [SerializeField] private List<AudioClip> m_CollisionSounds;
    [SerializeField] private int m_CollisionSounds_Counter;
    [SerializeField] private float m_CollisionSoundVolume;
    //[SerializeField] private AudioClip m_JumpSound;

    private Camera m_Camera;
    private float m_YRotation;
    private Vector2 m_Input;
    private Vector3 m_MoveDir = Vector3.zero;
    private CharacterController m_CharacterController;
    private CollisionFlags m_CollisionFlags;
    private bool m_PreviouslyGrounded;
    private Vector3 m_OriginalCameraPosition;
    private bool m_Jumping;
    public LayerMask groundLayer;
    public LayerMask obstacleLayer;
    private AudioSource m_AudioSource;
    //private bool m_Jump;

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

        if (!m_PreviouslyGrounded && m_CharacterController.isGrounded) {
            PlaySound(m_LandSounds[Random.Range(0, m_LandSounds.Count)], m_LandSoundVolume);
            //m_MoveDir.y = 0f;
            m_Jumping = false;
        }
        /*if(!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded) {
            m_MoveDir.y = 0f;
        }*/

        m_PreviouslyGrounded = m_CharacterController.isGrounded;
    }


    private void PlaySound(AudioClip clip,float volume) {
        m_AudioSource.PlayOneShot(clip, volume);
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


        //Edge Grinding Issue Fix
        //Debug.Log(Vector3.Dot(Vector3.up, hitInfo.normal));
        if(Vector3.Dot(Vector3.up, hitInfo.normal) > 0.1f) {
            desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;
        }

        m_MoveDir.x = desiredMove.x * speed;
        m_MoveDir.z = desiredMove.z * speed;


        Ray ray = new Ray(transform.position + transform.up * -0.7f + 0.4f * transform.forward, -transform.up * 2f);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        bool customGrounded = Physics.Raycast(ray, 0.4f, groundLayer);

        if(m_CharacterController.isGrounded && customGrounded) {

            if(customGrounded) {
                m_MoveDir.y = -m_StickToGroundForce;
            }


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

        /*//using two raycasts, try to align the body to the ground
        RaycastHit hit;
        Debug.DrawRay(m_body.position + m_body.up * -0.5f + 0.4f * m_body.forward, -m_body.up);
        if(Physics.Raycast(m_body.position + m_body.up * -0.5f + 0.4f * m_body.forward, -m_body.up, out hit, 1.3f, groundLayer)) {
            Vector3 normal1 = hit.normal;
        Debug.DrawRay(m_body.position + m_body.up * -0.5f + -0.4f * m_body.forward, -m_body.up);
            if(Physics.Raycast(m_body.position + m_body.up * -0.5f - 0.4f * m_body.forward, -m_body.up, out hit, 1.3f, groundLayer)) {
                Vector3 normal2 = hit.normal;
                if(Vector3.Dot(normal1, normal2) > 0.3f) {
                    Vector3 avgNormal = (normal1 + normal2).normalized;

                    Quaternion rotation = Quaternion.LookRotation(desiredMove, avgNormal);
                    m_body.rotation = Quaternion.Lerp(m_body.rotation, rotation, Time.deltaTime * 5f);
                }
            }
        }*/

        //use grounded normal
        Quaternion rotation = Quaternion.LookRotation(desiredMove, hitInfo.normal);
        m_body.rotation = Quaternion.Lerp(m_body.rotation, rotation, Time.deltaTime * 5f);

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

        if((obstacleLayer.value & 1 << hit.gameObject.layer) != 0) {
            PlaySound(m_CollisionSounds[Random.Range(0, m_CollisionSounds.Count)], m_CollisionSoundVolume);
            GameManager.Instance.Death();
        }


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

