using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TriggerEnterEvent : UnityEvent<Collider> { }
[System.Serializable]
public class CollisionEnterEvent : UnityEvent<Collision> { }

public class TriggerEvent : MonoBehaviour {

    [HideInInspector] public bool checkLayer;
    [HideInInspector] public int requireLayer;
    [HideInInspector] public bool checkTag;
    [HideInInspector] public string requireTag;
    public TriggerEnterEvent onTriggerEnterEvent = new TriggerEnterEvent();
    public CollisionEnterEvent onCollisionEnterEvent = new CollisionEnterEvent();

    void OnTriggerEnter(Collider other) {
        if (checkLayer && (other.gameObject.layer != requireLayer))
            return;
        if(checkTag && !other.gameObject.CompareTag(requireTag))
            return;
        onTriggerEnterEvent.Invoke(other);
    }

    private void OnCollisionEnter(Collision collision) {
        if(checkLayer && (collision.gameObject.layer != requireLayer))
            return;
        if(checkTag && !collision.gameObject.CompareTag(requireTag))
            return;
        onCollisionEnterEvent.Invoke(collision);
    }
}

#if UNITY_EDITOR

    [CustomEditor(typeof(TriggerEvent))]
    [CanEditMultipleObjects]
    public class TriggerEventEditor : Editor {

        public override void OnInspectorGUI() {
            TriggerEvent Script = (TriggerEvent)target;

            EditorGUILayout.BeginHorizontal();
            Script.checkLayer = EditorGUILayout.Toggle("Check Layer", Script.checkLayer);
            if(Script.checkLayer) {
                Script.requireLayer = EditorGUILayout.LayerField("Require Layer", Script.requireLayer);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            Script.checkTag = EditorGUILayout.Toggle("Check Tag", Script.checkTag);
            if(Script.checkTag) {
                Script.requireTag = EditorGUILayout.TextField("Require Tag", Script.requireTag);
            }
            EditorGUILayout.EndHorizontal();

            base.OnInspectorGUI();


        }
    }

#endif