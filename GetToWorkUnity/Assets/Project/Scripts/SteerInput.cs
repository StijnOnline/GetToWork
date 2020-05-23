using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;

public class SteerInput : MonoBehaviour {
    [Header("References")]
    [SerializeField] private Transform steer = null;
    [SerializeField] private Interactable leftHandleInteractable = null;
    [SerializeField] private Handle leftHandle = null;
    [SerializeField] private Interactable rightHandleInteractable = null;
    [SerializeField] private Handle rightHandle = null;

    [Header("Values")]
    [SerializeField] private float steerMultiplier = 1;

    [HideInInspector] public bool isBraking { get; private set; } = false;
    [HideInInspector] public float thruster { get; private set; } = 0;
    [HideInInspector] public float rudder { get; private set; } = 0;
    [HideInInspector] public bool leftGrabbed { get; private set; } = false;
    [HideInInspector] public bool rightGrabbed { get; private set; } = false;


    void Update() {
        rudder = steer.localRotation.x * steerMultiplier;

        leftGrabbed = leftHandleInteractable.attachedToHand != null;
        rightGrabbed = rightHandleInteractable.attachedToHand != null;
        if(leftGrabbed && rightGrabbed) {
            GameManager.Instance.StartGame();
        }

        thruster = GameManager.Instance.started ? 1 : 0;
    }

    public void ResetSteer() {

        steer.localRotation = Quaternion.identity;
        leftHandle.TryDetachAll();
        rightHandle.TryDetachAll();
    }
}