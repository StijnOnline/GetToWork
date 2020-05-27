using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAnimationsTrigger : MonoBehaviour
{
    [SerializeField] private List<Animator> animatorsToEnable;

    private void OnTriggerEnter(Collider other) {
        foreach(Animator a in animatorsToEnable) {
            a.enabled = true;
        }
    }
}