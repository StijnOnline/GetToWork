using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }
    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    [HideInInspector] public Vector3 spawnPointPosition;
    [HideInInspector] public Quaternion spawnPointRotation;
    [HideInInspector] public Vector3 lastPlayerLocalPos;
    [HideInInspector] public Quaternion lastPlayerLocalRot;
    [HideInInspector] public Transform playerObject = null;
    [HideInInspector] public Transform playerHead;
    [HideInInspector] public Transform bike;
}