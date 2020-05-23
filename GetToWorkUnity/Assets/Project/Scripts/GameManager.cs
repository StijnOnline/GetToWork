using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public string playerTag = "Player";


    public bool started { get; private set; } = false;
    private CheckPoint latestCheckPoint = null;
    [SerializeField] private Transform defaultSpawn = null;
    [SerializeField] private Rigidbody bikeRB = null;
    [SerializeField] private SteerInput steerInput = null;
    [SerializeField] private Rigidbody steerRB = null;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }

    public void StartGame() {
        started = true;
        bikeRB.isKinematic = false;
        steerRB.isKinematic = false;
        //should be temporary
        steerRB.transform.localPosition = Vector3.zero;
    }

    public void CheckPointReached(CheckPoint checkPoint) {
        latestCheckPoint = checkPoint;
    }

    //when player dies or falls
    public void Restart() {
        bikeRB.isKinematic = true;
        steerRB.isKinematic = true;
        started = false;
        if(latestCheckPoint != null) {
            bikeRB.position = latestCheckPoint.spawnPoint.position;
            bikeRB.rotation = latestCheckPoint.spawnPoint.rotation;
        } else {
            bikeRB.position = defaultSpawn.position;
            bikeRB.rotation = defaultSpawn.rotation;
        }
        steerInput.ResetSteer();
        Debug.Log("Restart");
    }
}
