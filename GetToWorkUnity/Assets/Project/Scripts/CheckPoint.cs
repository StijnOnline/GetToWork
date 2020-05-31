using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour {

    public Transform spawnPoint;
    public UnityEvent unityEvent;
    
    private bool reached = false;

    private void OnTriggerEnter(Collider other) {
        if(!reached && other.CompareTag(GameManager.Instance.playerTag)) {
            reached = true;
            GameManager.Instance.CheckPointReached(this);
            unityEvent.Invoke();
        }
    }
}
