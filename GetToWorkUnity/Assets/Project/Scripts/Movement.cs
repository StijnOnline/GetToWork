using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    public class Movement : MonoBehaviour {
        [Serializable]
        public class NewMovementSettings {
            public float BrakeSpeed = 8.0f;
            public float NormalSpeed = 12.0f;
            public float BoostSpeed = 16.0f;
            

            public float JumpForce = 30f;
            public AnimationCurve SlopeCurveModifier = new AnimationCurve(new Keyframe(-90.0f, 1.0f), new Keyframe(0.0f, 1.0f), new Keyframe(90.0f, 0.0f));

        }


        [Serializable]
        public class NewAdvancedSettings {
            public float groundCheckDistance = 0.01f; // distance for checking if the controller is grounded ( 0.01f seems to work best for this )
            public float stickToGroundHelperDistance = 0.5f; // stops the character
            public float slowDownRate = 20f; // rate at which the controller comes to a stop when there is no input
            public bool airControl; // can the user control the direction that is being moved in the air
            [Tooltip("set it to 0.1 or more if you get stuck in wall")]
            public float shellOffset = 0.1f; //reduce the radius by that ratio to avoid getting stuck in wall (a value of 0.1f is nice)
            public LayerMask groundLayer;
        }

        public NewMovementSettings movementSettings = new NewMovementSettings();
        public NewAdvancedSettings advancedSettings = new NewAdvancedSettings();


        private Rigidbody m_RigidBody;
        private CapsuleCollider m_Capsule;
        [SerializeField] private NewSteerInput m_SteerInput;
        private float m_YRotation;
        private Vector3 m_GroundContactNormal;
        private bool m_Jump, m_PreviouslyGrounded, m_Jumping, m_IsGrounded;


        public Vector3 Velocity {
            get { return m_RigidBody.velocity; }
        }

        public bool Grounded {
            get { return m_IsGrounded; }
        }


        private void Start() {
            m_RigidBody = GetComponent<Rigidbody>();
            m_Capsule = GetComponent<CapsuleCollider>();
        }


        private void Update() {
            RotateView();

            if(CrossPlatformInputManager.GetButtonDown("Jump") && !m_Jump) {
                m_Jump = true;
            }
        }

        private float GetTargetSpeed() {
            if(m_SteerInput.brake > 0.1f) {
                return movementSettings.BrakeSpeed;
            }else if(m_SteerInput.boost > 0.1f) {
                return movementSettings.BoostSpeed;
            } else {
                return movementSettings.NormalSpeed;
            }
        }


        private void FixedUpdate() {
            GroundCheck();

            if((GameManager.Instance == null || GameManager.Instance.started) && (advancedSettings.airControl || m_IsGrounded)) {
                float TargetSpeed = GetTargetSpeed();

                // always move along the camera forward as it is the direction that it being aimed at
                Vector3 desiredMove = transform.forward;
                desiredMove = Vector3.ProjectOnPlane(desiredMove, m_GroundContactNormal).normalized;
                desiredMove *= TargetSpeed;

                if(m_RigidBody.velocity.sqrMagnitude < (TargetSpeed * TargetSpeed)) {
                    m_RigidBody.AddForce(desiredMove * SlopeMultiplier(), ForceMode.Impulse);
                }
            }

            if(m_IsGrounded) {
                m_RigidBody.drag = 5f;

                if(m_Jump) {
                    m_RigidBody.drag = 0f;
                    m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0f, m_RigidBody.velocity.z);
                    m_RigidBody.AddForce(new Vector3(0f, movementSettings.JumpForce, 0f), ForceMode.Impulse);
                    m_Jumping = true;
                }
            } else {
                m_RigidBody.drag = 0f;
                if(m_PreviouslyGrounded && !m_Jumping) {
                    StickToGroundHelper();
                }
            }
            m_Jump = false;
        }


        private float SlopeMultiplier() {
            float angle = Vector3.Angle(m_GroundContactNormal, Vector3.up);
            return movementSettings.SlopeCurveModifier.Evaluate(angle);
        }


        private void StickToGroundHelper() {
            RaycastHit hitInfo;
            if(Physics.SphereCast(transform.position, m_Capsule.radius * (1.0f - advancedSettings.shellOffset), Vector3.down, out hitInfo,
                                   ((m_Capsule.height / 2f) - m_Capsule.radius) +
                                   advancedSettings.stickToGroundHelperDistance, Physics.AllLayers, QueryTriggerInteraction.Ignore)) {
                if(Mathf.Abs(Vector3.Angle(hitInfo.normal, Vector3.up)) < 85f) {
                    m_RigidBody.velocity = Vector3.ProjectOnPlane(m_RigidBody.velocity, hitInfo.normal);
                }
            }
        }


        private void RotateView() {
            //avoids the mouse looking if the game is effectively paused
            if(Mathf.Abs(Time.timeScale) < float.Epsilon) return;

            if(m_IsGrounded || advancedSettings.airControl) {
                // Rotate the rigidbody velocity to match the new direction that the character is looking
                Quaternion Rotation = Quaternion.AngleAxis(m_SteerInput.Steering, Vector3.up);
                transform.rotation *= Rotation;
                m_RigidBody.velocity = Rotation * m_RigidBody.velocity;
            }
        }

        /// sphere cast down just beyond the bottom of the capsule to see if the capsule is colliding round the bottom
        private void GroundCheck() {
            m_PreviouslyGrounded = m_IsGrounded;
            RaycastHit hitInfo;
            if(Physics.SphereCast(transform.position, m_Capsule.radius * (1.0f - advancedSettings.shellOffset), Vector3.down, out hitInfo,
                                   ((m_Capsule.height / 2f) - m_Capsule.radius) + advancedSettings.groundCheckDistance, advancedSettings.groundLayer, QueryTriggerInteraction.Ignore)) {
                m_IsGrounded = true;
                m_GroundContactNormal = hitInfo.normal;
            } else {
                m_IsGrounded = false;
                m_GroundContactNormal = Vector3.up;
            }
            if(!m_PreviouslyGrounded && m_IsGrounded && m_Jumping) {
                m_Jumping = false;
            }
        }
    }
