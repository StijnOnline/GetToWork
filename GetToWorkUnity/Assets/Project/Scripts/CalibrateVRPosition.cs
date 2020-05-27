using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CalibrateVRPosition : MonoBehaviour
{
    public Transform playerObject;
    public Transform playerHead;
    public Transform headTarget;

    public SteamVR_Action_Boolean calibrateAction;
    public SteamVR_Input_Sources inputSource;

    public Vector3 lastPlayerLocalPos;
    public Quaternion lastPlayerLocalRot;

    void OnEnable() {
        calibrateAction.AddOnStateDownListener(Calibrate, inputSource);
        lastPlayerLocalPos = playerObject.localPosition;
    }

    //todo calibrate rotation?
    private void Calibrate(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) {
        playerObject.position += headTarget.position - playerHead.position;
        lastPlayerLocalPos = playerObject.localPosition;
        lastPlayerLocalRot = playerObject.localRotation;
    }

    public void PositionPlayer() {
        playerObject.localPosition = lastPlayerLocalPos;
        playerObject.localRotation = lastPlayerLocalRot;
    }
}
