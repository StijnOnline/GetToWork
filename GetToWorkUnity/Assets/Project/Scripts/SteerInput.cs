using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;

public class SteerInput : MonoBehaviour {
    [Header("References")]
    [SerializeField] private Transform steer = null;
    [SerializeField] private Interactable leftHandle = null;
    [SerializeField] private Interactable rightHandle = null;

    [Header("Values")]
    [SerializeField] private float steerMultiplier = 1;

    [HideInInspector] public bool isBraking { get; private set; } = false;
    [HideInInspector] public float thruster { get; private set; } = 0;
    [HideInInspector] public float rudder { get; private set; } = 0;
    [HideInInspector] public bool leftGrabbed { get; private set; } = false;
    [HideInInspector] public bool rightGrabbed { get; private set; } = false;


    void Update() {
        rudder = steer.rotation.x * steerMultiplier;

        leftGrabbed = leftHandle.attachedToHand != null;
        rightGrabbed = rightHandle.attachedToHand != null;
        if(leftGrabbed && rightGrabbed) {
            GameManager.Instance.StartGame();
        }

        thruster = GameManager.Instance.started ? 1 : 0;
    }
}