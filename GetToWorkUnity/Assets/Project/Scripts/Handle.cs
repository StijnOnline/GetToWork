﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class Handle: MonoBehaviour {
    private List<Hand> holdingHands = new List<Hand>();
    public Rigidbody steerRigidbody;

    [EnumFlags]
    public Hand.AttachmentFlags attachmentFlags = 0;
    public float attachForce;
    public float attachForceDamper;
    
    public GameObject fakeHand;

    private void Start() {
        fakeHand.SetActive(false);
    }

    void Update() {
        //HAHA NO DETACHING HANDS
        /*for(int i = 0; i < holdingHands.Count; i++) {
            if(holdingHands[i].IsGrabEnding(this.gameObject)) {
                Detach(holdingHands[i]);
            }
        }*/
    }

    private void HandHoverUpdate(Hand hand) {
        GrabTypes startingGrabType = hand.GetGrabStarting();
        if(startingGrabType == GrabTypes.Grip) {
            Attach(hand, startingGrabType);
        }
    }

    private void Attach(Hand hand, GrabTypes startingGrabType) {
        Detach(hand);
        hand.AttachObject(this.gameObject, startingGrabType, attachmentFlags);
        // Don't let the hand interact with other things while it's holding us
        hand.HoverLock(null);
        holdingHands.Add(hand);
        fakeHand.SetActive(true);
    }

    private void Detach(Hand hand) {
        int i = holdingHands.IndexOf(hand);
        if(i != -1) {
            // Allow the hand to do other things
            holdingHands[i].HoverUnlock(null);
            holdingHands[i].DetachObject(this.gameObject, false);
            Util.FastRemove(holdingHands, i);
            fakeHand.SetActive(false);
        }
    }

    public void TryDetachAll() {
        for(int i = 0; i < holdingHands.Count; i++) {
            Detach(holdingHands[i]);
        }
    }

    void FixedUpdate() {
        for(int i = 0; i < holdingHands.Count; i++) {
            Vector3 vdisplacement = holdingHands[i].objectAttachmentPoint.transform.position - transform.position;
            vdisplacement = vdisplacement.normalized;
            steerRigidbody.AddForceAtPosition(attachForce * vdisplacement, transform.position, ForceMode.Force);
            steerRigidbody.AddForceAtPosition(-attachForceDamper * steerRigidbody.GetPointVelocity(transform.position), transform.position, ForceMode.Force);
        }

    }
}