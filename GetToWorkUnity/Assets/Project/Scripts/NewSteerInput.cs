using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;
using Valve.VR;
using System;

public class NewSteerInput : MonoBehaviour {
    [Header("References")]
    [SerializeField] private Transform steer = null;
    [SerializeField] private Interactable leftHandleInteractable = null;
    [SerializeField] private Handle leftHandle = null;
    [SerializeField] private Interactable rightHandleInteractable = null;
    [SerializeField] private Handle rightHandle = null;

    [Header("Values")]
    [SerializeField] private float steerMultiplier = 1;
    [SerializeField] private float steerThreshold = 0.05f;

    public float brake { get; private set; } = 0;
    public float boost { get; private set; } = 0;

    [HideInInspector] public float Steering { get; private set; } = 0;

    private bool leftGrabbed = false;
    private bool rightGrabbed = false;

    public SteamVR_Action_Single brakeAction;
    public SteamVR_Input_Sources brakeSource;
    public SteamVR_Action_Single boostAction;
    public SteamVR_Input_Sources boostSource;


    [Header("Audio")]
    [SerializeField] private AudioClip m_boostSound;
    [SerializeField] private float m_boostSoundVolume;
    [SerializeField] private AudioClip m_brakeSound;
    [SerializeField] private float m_brakeSoundVolume;
    private AudioSource m_AudioSource;



    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        if (m_AudioSource == null)
        {
            m_AudioSource = gameObject.AddComponent<AudioSource>();
        }
    }


    void Update() {
        float relativeAngle = (steer.localRotation.eulerAngles.x + 180) % 360 - 180;
        Steering = Mathf.Abs(relativeAngle) > steerThreshold ? relativeAngle * steerMultiplier : 0;

        leftGrabbed = leftHandleInteractable.attachedToHand != null;
        rightGrabbed = rightHandleInteractable.attachedToHand != null;
        if(leftGrabbed && rightGrabbed) {
            GameManager.Instance.StartGame();
        }

        // boost audio
        m_AudioSource.volume = Mathf.Lerp(m_AudioSource.volume, boost, 0.1f);
    }

    void OnEnable() {
        brakeAction.AddOnChangeListener(Brake, brakeSource);
        boostAction.AddOnChangeListener(Accellerate, boostSource);
        //GameData.Instance.lastPlayerLocalPos = GameData.Instance.playerObject.localPosition;
    }

    private void Brake(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta) {
        if(leftGrabbed) {
            brake = newAxis;
            m_AudioSource.PlayOneShot(m_brakeSound, m_brakeSoundVolume);
        }
      
    }

    private void Accellerate(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta) {
        if(rightGrabbed) {
            boost = newAxis;
            m_AudioSource.clip = m_boostSound;
            m_AudioSource.Play();
        }
    }

    public void ResetSteer() {

        steer.localRotation = Quaternion.identity;
        leftHandle.TryDetachAll();
        rightHandle.TryDetachAll();
    }

    public void SetBrake(float brake) {
        this.brake = brake;
        m_AudioSource.PlayOneShot(m_brakeSound, m_brakeSoundVolume);
    }
    public void SetBoost(float boost) {
        this.boost = boost;

        if (!m_AudioSource.isPlaying)
        {
            m_AudioSource.clip = m_boostSound;
            m_AudioSource.Play();
        }
    }
}