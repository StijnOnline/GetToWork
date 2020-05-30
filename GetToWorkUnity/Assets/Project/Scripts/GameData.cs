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

    public Vector3 spawnPointPosition;
    public Quaternion spawnPointRotation;
    public Vector3 lastPlayerLocalPos;
    public Quaternion lastPlayerLocalRot;
    public Transform playerObject = null;
    public Transform playerHead;
    public Transform bike;
}