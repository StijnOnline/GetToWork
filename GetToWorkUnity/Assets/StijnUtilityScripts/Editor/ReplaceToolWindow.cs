using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Threading.Tasks;

public class ReplaceToolWindow : EditorWindow {

    
    private GameObject targetObject = null;
    private Vector3 positionOffset = Vector3.zero;
    private Vector3 rotationOffset = Vector3.zero;
    private float scaleMultiplier = 1f;

    private GameObject originalObject = null;
    private GameObject replacedObject = null;

    [MenuItem("Window/Replace Selection")]
    static void Init() {
        ReplaceToolWindow window = (ReplaceToolWindow)EditorWindow.GetWindow(typeof(ReplaceToolWindow));
    }

    void OnGUI() {


        GUILayout.Label("Simple Replace", EditorStyles.boldLabel);
        targetObject = (GameObject)EditorGUILayout.ObjectField(targetObject, typeof(GameObject));
        positionOffset = EditorGUILayout.Vector3Field("Position Offset", positionOffset);
        rotationOffset = EditorGUILayout.Vector3Field("Rotation Offset", rotationOffset);
        scaleMultiplier = EditorGUILayout.FloatField("Scale Multiplier", scaleMultiplier);

        if(GUILayout.Button("Replace Selection")) {
            SimpleReplace();
        }

        GUILayout.Space(20);
        GUILayout.Label("Copy Replace", EditorStyles.boldLabel);
        originalObject = (GameObject)EditorGUILayout.ObjectField("Original Object", originalObject, typeof(GameObject));
        replacedObject = (GameObject)EditorGUILayout.ObjectField("Replaced Object", replacedObject, typeof(GameObject));

        if(GUILayout.Button("Replace Selection")) {
            CopyReplace();
        }
    }

    void SimpleReplace() {
        if(targetObject == null)
            return;
        if(Selection.transforms.Length == 0)
            return;

        foreach(GameObject referenceObject in Selection.gameObjects) {
            //Create New
            Vector3 globalPostionOffset = referenceObject.transform.TransformDirection(positionOffset);
            GameObject created = Instantiate(targetObject,referenceObject.transform.position + globalPostionOffset, referenceObject.transform.rotation * Quaternion.Euler(rotationOffset));
            created.transform.localScale *= scaleMultiplier;
            Undo.RegisterCreatedObjectUndo(created,"Created Replacement");
            Undo.DestroyObjectImmediate(referenceObject);
        }
    }

    void CopyReplace() {
        if(originalObject == null)
            return;
        if(replacedObject == null)
            return;
        if(Selection.transforms.Length == 0)
            return;

        float relativeScale = replacedObject.transform.lossyScale.magnitude / originalObject.transform.lossyScale.magnitude;
        Quaternion relativeRotation = Quaternion.RotateTowards(originalObject.transform.rotation, replacedObject.transform.rotation, float.MaxValue);
        Vector3 relativePos = replacedObject.transform.position - originalObject.transform.transform.position;        

        foreach(GameObject referenceObject in Selection.gameObjects) {
            //Create New
            Vector3 globalPostionOffset = replacedObject.transform.InverseTransformDirection(relativePos);
            GameObject created = Instantiate(replacedObject, referenceObject.transform.position + globalPostionOffset, referenceObject.transform.rotation * relativeRotation);
            created.transform.localScale *= relativeScale;
            Undo.RegisterCreatedObjectUndo(created, "Created Replacement");
            Undo.DestroyObjectImmediate(referenceObject);
        }
    }
}
