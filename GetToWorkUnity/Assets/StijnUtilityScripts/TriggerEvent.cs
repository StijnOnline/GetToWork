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
    public bool checkLayer;
    public int requireLayer;
    public bool checkTag;
    public string requireTag;
    public TriggerEnterEvent onTriggerEnterEvent = new TriggerEnterEvent();
    public CollisionEnterEvent onCollisionEnterEvent = new CollisionEnterEvent();

    void OnTriggerEnter(Collider other) {
        if(checkLayer && (requireLayer & 1 << other.gameObject.layer) == 0)
            return;
        if(checkTag && !other.gameObject.CompareTag(requireTag))
            return;
        onTriggerEnterEvent.Invoke(other);
    }

    private void OnCollisionEnter(Collision collision) {
        if(checkLayer && (requireLayer & 1 << collision.gameObject.layer) == 0)
            return;
        if(checkTag && !collision.gameObject.CompareTag(requireTag))
            return;
        onCollisionEnterEvent.Invoke(collision);
    }
}

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

        SerializedProperty onTriggerEnterEventProperty = serializedObject.FindProperty("onTriggerEnterEvent"); // <-- UnityEvent
        EditorGUILayout.PropertyField(onTriggerEnterEventProperty);
        
        SerializedProperty onCollisionEnterEventProperty = serializedObject.FindProperty("onCollisionEnterEvent"); // <-- UnityEvent
        EditorGUILayout.PropertyField(onCollisionEnterEventProperty);

    }
}