using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    public Transform spawnPoint;
    
    private bool reached = false;

    private void OnTriggerEnter(Collider other) {
        if(!reached && other.CompareTag(GameManager.Instance.playerTag)) {
            reached = true;
            GameManager.Instance.CheckPointReached(this);

            //particles and audio or something
        }
    }
}
