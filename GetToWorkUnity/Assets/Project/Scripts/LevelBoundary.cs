using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == GameManager.Instance.playerTag) {
            GameManager.Instance.Death();

            //other stuff?
        }
    }
}
