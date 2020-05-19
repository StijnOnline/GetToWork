using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public string playerTag = "Player";


    public bool started { get; private set; } = false;
    private CheckPoint latestCheckPoint = null;
    [SerializeField] private Transform defaultSpawn = null;
    [SerializeField] private Rigidbody bike = null;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }

    public void StartGame() {
        started = true;
        bike.isKinematic = false;
    }

    public void CheckPointReached(CheckPoint checkPoint) {
        latestCheckPoint = checkPoint;
    }

    //when player dies or falls
    public void Restart() {
        bike.isKinematic = true;
        started = false;
        if(latestCheckPoint != null) {
            bike.position = latestCheckPoint.spawnPoint.position;
            bike.rotation = latestCheckPoint.spawnPoint.rotation;
        } else {
            bike.position = defaultSpawn.position;
            bike.rotation = defaultSpawn.rotation;
        }
        Debug.Log("Restart");
    }
}
