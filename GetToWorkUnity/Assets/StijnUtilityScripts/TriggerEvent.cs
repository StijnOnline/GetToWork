using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyTriggerEvent : UnityEvent<Collider> { }

public class TriggerEvent : MonoBehaviour
{
    public MyTriggerEvent triggerEvent = new MyTriggerEvent();

    private void OnTriggerEnter(Collider other) {
        triggerEvent.Invoke(other);
    }
}
