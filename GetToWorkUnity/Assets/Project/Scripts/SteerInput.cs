using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;
using Valve.VR;
using System;

public class SteerInput : MonoBehaviour {
    [Header("References")]
    [SerializeField] private Transform steer = null;
    [SerializeField] private Interactable leftHandleInteractable = null;
    [SerializeField] private Handle leftHandle = null;
    [SerializeField] private Interactable rightHandleInteractable = null;
    [SerializeField] private Handle rightHandle = null;

    [Header("Values")]
    [SerializeField] private float steerMultiplier = 1;

    private float brake = 0;
    private float boost = 0;
    [SerializeField] private float defaultTerminalVelocity = 15;
    [SerializeField] private float minimumTerminalVelocity = 10;
    [SerializeField] private float boostMultiplier = 0.5f;
    [HideInInspector] public float terminalVelocity { 
        get{ 
            return Mathf.Lerp(  defaultTerminalVelocity * (boostMultiplier * boost + 1), minimumTerminalVelocity, brake); 
        } 
    }
    [HideInInspector] public float thruster { get; private set; } = 0;
    [HideInInspector] public float rudder { get; private set; } = 0;
    [HideInInspector] public bool leftGrabbed { get; private set; } = false;
    [HideInInspector] public bool rightGrabbed { get; private set; } = false;

    public SteamVR_Action_Single brakeAction;
    public SteamVR_Input_Sources brakeSource;
    public SteamVR_Action_Single boostAction;
    public SteamVR_Input_Sources boostSource;


    void Update() {
        rudder = steer.localRotation.x * steerMultiplier;

        leftGrabbed = leftHandleInteractable.attachedToHand != null;
        rightGrabbed = rightHandleInteractable.attachedToHand != null;
        if(leftGrabbed && rightGrabbed) {
            GameManager.Instance.StartGame();
        }

        //brake = Mathf.Lerp(brake,0,0.1f);
        //boost = Mathf.Lerp(boost, 0,0.1f);

        thruster = GameManager.Instance.started ? 1 : 0;
    }

    void OnEnable() {
        brakeAction.AddOnChangeListener(Brake, brakeSource);
        boostAction.AddOnChangeListener(Accellerate, boostSource);
        //GameData.Instance.lastPlayerLocalPos = GameData.Instance.playerObject.localPosition;
    }

    private void Brake(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta) {
        if(leftGrabbed) {
            brake = newAxis;
        }
    }

    private void Accellerate(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta) {
        if(rightGrabbed) {
            boost = newAxis;
        }
    }

    public void ResetSteer() {

        steer.localRotation = Quaternion.identity;
        leftHandle.TryDetachAll();
        rightHandle.TryDetachAll();
    }

    public void SetBrake(float brake) {
        this.brake = brake;
    }
    public void SetBoost(float boost) {
        this.boost = boost;
    }
}