using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Valve.VR;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public string playerTag = "Player";
    public bool started { get; private set; } = false;
    private CheckPoint latestCheckPoint = null;
    [SerializeField] private Transform defaultSpawn = null;
    [SerializeField] private Transform player = null;
    [SerializeField] private Transform playerHead = null;
    [SerializeField] private Rigidbody bikeRB = null;
    [SerializeField] private SteerInput steerInput = null;
    [SerializeField] private Rigidbody steerRB = null;
    [SerializeField] private CalibrateVRPosition calibrateVR = null;
    [SerializeField] private VehicleMovement vehicleMovement = null;


    private void Start() {
        if(Instance != null && Instance != this) {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }

        if(GameData.Instance.spawnPointPosition != Vector3.zero) {
            bikeRB.position = GameData.Instance.spawnPointPosition;
            bikeRB.rotation = GameData.Instance.spawnPointRotation;
        } else {
            bikeRB.position = defaultSpawn.position;
            bikeRB.rotation = defaultSpawn.rotation;
        }

        GameData.Instance.playerObject = player;
        GameData.Instance.playerHead = playerHead;
        if(GameData.Instance.playerObject == null) {
            /*GameData.Instance.playerObject = player;
            GameData.Instance.playerHead = playerHead;
            GameData.Instance.playerObject.transform.parent = bikeRB.transform;
            GameData.Instance.bike = bikeRB.transform;*/

        } else {
            //Destroy(bikeRB.gameObject);
            //Destroy(player.gameObject);
            //GameData.Instance.playerObject.transform.parent = bikeRB.transform;
            //bikeRB = GameData.Instance.bike.GetComponent<Rigidbody>();

        }

        if(GameData.Instance.lastPlayerLocalPos != Vector3.zero) {
            calibrateVR.PositionPlayer();
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
        GameData.Instance.spawnPointPosition = latestCheckPoint.spawnPoint.position;
        GameData.Instance.spawnPointRotation = latestCheckPoint.spawnPoint.rotation;
    }

    //when player dies or falls
    public void Death() {
        //GameData.Instance.playerObject.SetParent(null);
        player.parent = null;
        vehicleMovement.enabled = false;
        bikeRB.useGravity = true;

        Invoke("Restart",2f);
    }

    public void Restart() {
        /*player.SetParent(bikeRB.transform);
        calibrateVR.PositionPlayer();

        vehicleMovement.enabled = true;
        bikeRB.useGravity = false;
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
        steerInput.ResetSteer();*/

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(bikeRB.gameObject);
        Destroy(player.gameObject);

        SteamVR_LoadLevel.Begin(SceneManager.GetActiveScene().name);
        Debug.Log("Restarted");
    }
}
