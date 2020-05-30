using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CalibrateVRPosition : MonoBehaviour
{
    public Transform headTarget;

    public SteamVR_Action_Boolean calibrateAction;
    public SteamVR_Input_Sources inputSource;


    void OnEnable() {
        calibrateAction.AddOnStateDownListener(Calibrate, inputSource);
        //GameData.Instance.lastPlayerLocalPos = GameData.Instance.playerObject.localPosition;
    }

    //todo calibrate rotation?
    private void Calibrate(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) {
        GameData.Instance.playerObject.position += headTarget.position - GameData.Instance.playerHead.position;
        GameData.Instance.lastPlayerLocalPos = GameData.Instance.playerObject.localPosition;
        GameData.Instance.lastPlayerLocalRot = GameData.Instance.playerObject.localRotation;
    }

    public void PositionPlayer() {
        GameData.Instance.playerObject.localPosition = GameData.Instance.lastPlayerLocalPos;
        GameData.Instance.playerObject.localRotation = GameData.Instance.lastPlayerLocalRot;
    }
}